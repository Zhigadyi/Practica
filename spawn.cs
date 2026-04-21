using UnityEngine;

public class spawn:MonoBehaviour
{
    public GameObject[] prefab; 
    public float minPos;
    public float maxPos;
    public void SpawnObject()
    {
        Vector3 randomPos = new Vector3(
        Random.Range(minPos, maxPos),
        0,
        Random.Range(minPos, maxPos)
        );
        int index = Random.Range(0, prefab.Length);
        Instantiate(prefab[index], randomPos, Quaternion.identity);
    }
    private void Start()
    {
            
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnObject();
        }
    }
}
