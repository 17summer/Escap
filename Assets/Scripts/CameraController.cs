using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //get the movement speed of mouse
    private float mouseX;
    private float mouseY;

    public float xRotation;

    //mouse sensitive
    public float mouseSens;

    //get the transform of the character that player controlled 
    public Transform player;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        mouseX = Input.GetAxis("Mouse X") * mouseSens * Time.deltaTime;
        mouseY = Input.GetAxis("Mouse Y") * mouseSens * Time.deltaTime;

        xRotation -= mouseY; 

        xRotation = Mathf.Clamp(xRotation,-60.0f,60.0f);

        player.Rotate(Vector3.up * mouseX);
        transform.localRotation = Quaternion.Euler(xRotation,0,0);
    }
}
