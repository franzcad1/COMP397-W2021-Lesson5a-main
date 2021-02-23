using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlPanelController : MonoBehaviour
{
    public RectTransform rectTransform;
    public  Vector2 offScreenPosition;
    public  Vector2 onScreenPosition;
    public float timer = 0.0f;
    [Range(0.1f, 10.0f)]
    public float speed = 5.0f;
    public bool isOnScreen = false;

    public CameraController playerCamera;

    // Start is called before the first frame update
    void Start()
    {
        playerCamera = FindObjectOfType<CameraController>();
        rectTransform = GetComponent<RectTransform>();

       

        timer = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
           
          
            isOnScreen = !isOnScreen;
            timer = 0.0f;
            if (isOnScreen)
            {
                Cursor.lockState = CursorLockMode.None;
                playerCamera.enabled = false;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                playerCamera.enabled = true;
            }
        }

        if (isOnScreen)
        {
            MoveControlPanelDown();
        }
        else
        {
            MoveControlPanelUp();
        }
    }

    private void MoveControlPanelDown()
    {

        rectTransform.anchoredPosition =  Vector2.Lerp(offScreenPosition, onScreenPosition, timer);
       
        if (timer < 1.0f)
        {
            timer += Time.deltaTime * speed;
        }
    }

    private void MoveControlPanelUp()
    {

        rectTransform.anchoredPosition = Vector2.Lerp(onScreenPosition, offScreenPosition, timer);

        if (timer < 1.0f)
        {
            timer += Time.deltaTime * speed;
        }
    }
}
