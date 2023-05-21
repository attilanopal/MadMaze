using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FpsMovement : MonoBehaviour
{
    float rotationX = 0f;
    float rotationY = 0f;

    public float sensitivity = 5f;
    public Transform orientation;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
            rotationY += Input.GetAxis("Mouse X") * sensitivity;
            rotationX += Input.GetAxis("Mouse Y") * -1 * sensitivity;
            rotationX = Mathf.Clamp(rotationX, -90f, 90f);

            transform.localEulerAngles = new Vector3(rotationX, rotationY, 0);
            orientation.localEulerAngles = new Vector3(0, rotationY, 0);
    }
}
