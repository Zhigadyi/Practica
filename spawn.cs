
using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;

public class spawn:MonoBehaviour
{
    public GameObject MetkaKorb;
    public GameObject MetkaOgnetushitel;
    public GameObject MetkaShlang;
    public GameObject MetkaPlana;
    public GameObject[] prefabBox;
    public GameObject[] prefabExtinguisher;
    public GameObject[] prefabHose;
    public GameObject[] prefabPlans;
    public List<GameObject> musornyeObjects = new List<GameObject>();
    public float minPos;
    public float maxPos;
    
    public void SpawnObject(Transform koor, GameObject obect)
    {
        var spawnedCube = Instantiate(
            obect,
            koor.position,
            koor.rotation
        );
        
        musornyeObjects.Add( spawnedCube);
    }
    private void Start()
    {
        
    }

    public void IniObjects(TochkiObekty[] tch)
    {
       
        for (int i = 0; i < tch.Length; i++)
        {
            var rand = Random.Range(0, tch[i].objects.Length);

            SpawnObject(tch[i].koor.transform, tch[i].objects[rand]);
            
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
        TochkiObekty korb = new TochkiObekty()
        {
            koor = MetkaKorb,
            objects = prefabBox,
            privyazkaKDocheryam = new TochkiObekty[] { shlang, ognetush }
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
    private void Update()
    {
        

    }
}
