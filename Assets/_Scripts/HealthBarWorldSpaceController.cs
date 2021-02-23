using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarWorldSpaceController : MonoBehaviour
{
    public Transform playerCamera;

    private void Start()
    {
        playerCamera = GameObject.Find("PlayerCam").GetComponent<Transform>();
    }
    void LateUpdate()
    {
        transform.LookAt(transform.position + playerCamera.forward);
    }
}
