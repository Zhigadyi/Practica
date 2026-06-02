using UnityEngine;

public class Raycast : MonoBehaviour
{
    public Camera camera = new Camera();
    private Input gameInput;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameInput = new Input();
        gameInput.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        
        Ray ray = camera.ScreenPointToRay(new Vector3(Screen.width/2, Screen.height/2, 0));
        RaycastHit hit;
        Debug.DrawRay(ray.origin, ray.direction, Color.red);
        if (Physics.Raycast(ray, out hit))
        {
            var interactable = hit.collider.GetComponent<IDeistvie>();
            if (interactable != null)
            {
                Debug.Log("Popal");
            }
            
            if (gameInput.GameInput.Interact.WasPerformedThisFrame())
            {
                if (interactable != null)
                {
                    interactable.Deistvie();
                    Debug.Log("Deistvie");
                }
            }
        }
    }
}
