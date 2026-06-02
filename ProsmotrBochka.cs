using UnityEngine;

public class ProsmotrBochka : MonoBehaviour, IDeistvie
{
    private bool NaMesteLi = false;
    private Vector3 StaryeKoor;
    public void Deistvie()
    {
        StaryeKoor = Camera.main.transform.position;
        NaMesteLi = true;
        //Camera.main.transform.position = transform.position;
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (NaMesteLi)
        {

            var cameraKoor = Camera.main.transform.position;
            var kudaX = Mathf.Sign(transform.position.x - cameraKoor.x);
            var kudaY = Mathf.Sign(transform.position.y - cameraKoor.y);
            var kudaZ = Mathf.Sign(transform.position.z - cameraKoor.z);
            if (kudaX + kudaY + kudaZ == 0)
                NaMesteLi = false;
            Camera.main.transform.position = new Vector3(cameraKoor.x+kudaX*0.001f, cameraKoor.y+kudaY * 0.001f, cameraKoor.z+kudaZ * 0.001f);
        }
    }
}
