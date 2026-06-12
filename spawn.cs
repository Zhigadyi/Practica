using TMPro;
using UnityEngine.UI;
using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;
using System.IO;

public class spawn:MonoBehaviour
{
    public GameObject[] MetkaKorb;
    public GameObject[] MetkaOgnetushitel;
    public GameObject[] MetkaShlang;
    public GameObject[] MetkaPlana;
    public GameObject[] MetkaKluch;
    public GameObject[] prefabKluch;
    public GameObject[] prefabBox;
    public GameObject[] prefabExtinguisher;
    public GameObject[] prefabHose;
    public GameObject[] prefabPlans;
    public List<GameObject> musornyeObjects = new List<GameObject>();
    public List<JsonData> jsonDatas = new List<JsonData>();
    public float minPos;
    public float maxPos;
    public Toggle[] toggle;

    public void SpawnObject(Transform koor, GameObject obect)
    {
        var spawnedCube = Instantiate(
            obect,
            koor.position,
            koor.rotation
        );
        
        musornyeObjects.Add( spawnedCube);
        SaveData saveData = new SaveData();
        saveData.objects = jsonDatas;

        string json = JsonUtility.ToJson(saveData, true);
        File.WriteAllText(@"C:\My project\Assets\save.json", json);
    }
    private void Start()
    {
        
    }

    public void IniObjects(TochkiObekty[] tch)
    {
       
        for (int i = 0; i < tch.Length; i++)
        {

            for (int j = 0; j < tch[i].koor.Length; j++) {
                var rand = Random.Range(0, tch[i].objects.Length+1);
                bool norms = false;
                if (rand == 1) norms = true;
                
                if (rand >= tch[i].objects.Length) { 
                    jsonDatas.Add(new JsonData { name = tch[i].objects[0].name, norm = norms });
                    continue;
                }
                jsonDatas.Add(new JsonData { name = tch[i].objects[rand].name, norm = norms });
                SpawnObject(tch[i].koor[j].transform, tch[i].objects[rand]);
                
            }
            
            if (tch[i].privyazkaKDocheryam != null)
                IniObjects(tch[i].privyazkaKDocheryam);
        }
    }
    public void OnButtonClick()
    {
        TochkiObekty shlang = new TochkiObekty()
        {
            koor = MetkaShlang,
            objects = prefabHose,
        };
        TochkiObekty ognetush = new TochkiObekty()
        {
            koor = MetkaOgnetushitel,
            objects = prefabExtinguisher,
        };
        TochkiObekty kluch = new TochkiObekty()
        {
            koor = MetkaKluch,
            objects = prefabKluch,
        };
        TochkiObekty korb = new TochkiObekty()
        {
            koor = MetkaKorb,
            objects = prefabBox,
            privyazkaKDocheryam = new TochkiObekty[] { shlang, ognetush, kluch }
        };
        TochkiObekty plan = new TochkiObekty()
        {
            koor = MetkaPlana,
            objects = prefabPlans,
        };
        var tch = new TochkiObekty[]{
            korb,
            plan
        };
        if (musornyeObjects != null)
        {
            foreach (GameObject obj in musornyeObjects)
            {
                if (obj != null)
                {
                    Destroy(obj);
                }
            }
        }
        musornyeObjects.Clear();
        IniObjects(tch);
    }

    public void OnButtonClickResult()
    {
        for (int i = 0; i < toggle.Length; i++)
        {
            if(jsonDatas[i].norm != toggle[i].isOn) Debug.Log("Ne Pravilno");
        }
    }
    private void Update()
    {
        

    }
}
