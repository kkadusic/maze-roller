using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;
    public float speedH = 2.0f;
    public float speedV = 2.0f;

    private float yaw = 0.0f;
    private float pitch = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.transform.position;
    }


    // Update is called once per frame
    void LateUpdate()
    { 
        yaw += speedH * Input.GetAxis("Mouse X");
        pitch -= speedV * Input.GetAxis("Mouse Y");
        if (pitch > 60) {
            pitch = 60;
        }
        else if (pitch < 0) {
            pitch = 0;
        }
        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
        transform.position = player.transform.position + offset;
    }
}
