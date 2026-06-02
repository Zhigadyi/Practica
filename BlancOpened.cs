using UnityEngine;

public class BlancOpened : MonoBehaviour
{
    public GameObject paper;
    private Input gameInput;

    bool opened = false;
    void Start()
    {
        gameInput = new Input();
        gameInput.Enable();
    }
    void Update()
    {
        if (gameInput.GameInput.OpenCheckList.WasPerformedThisFrame())
        {
            opened = !opened;

            paper.SetActive(opened);

            if (opened)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;

            }
            else
            {
                paper.transform.position = transform.position + transform.forward * 2f;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }
    }
}
