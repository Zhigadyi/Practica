using UnityEngine;

public class Baricade : MonoBehaviour
{
    public bool baricade;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.layer ==
            LayerMask.NameToLayer("objects"))
        {
            baricade = true;
            Debug.Log("Столкновение с objects");
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
