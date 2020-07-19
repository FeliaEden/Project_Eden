using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraContr : MonoBehaviour
{
    private const float Y_ANGLE_MIN = 0.0f;
    private const float Y_ANGLE_MAX = 50.0f;

    public Transform lookAt;
    public Transform camTrans;

    private Camera cam;

    private float distance = 10.0f;
    private float currentX = 0.0f;
    private float currentY = 0.0f;
    private float sensitivityX = 5.0f;
    private float sensitivityY = 4.0f;
    private int zoomSensitivity = 2;

    private void Start()
    {
        camTrans = transform;
        cam = Camera.main;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            currentX += Input.GetAxis("Mouse X") * sensitivityX;
            currentY += Input.GetAxis("Mouse Y") * sensitivityY;

            currentY = Mathf.Clamp(currentY, Y_ANGLE_MIN, Y_ANGLE_MAX);
        }

        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            GetComponent<Camera>().fieldOfView++;
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            GetComponent<Camera>().fieldOfView--;
        }
    }

    private void LateUpdate()
    {
        Vector3 dir = new Vector3(0, 0, -distance);
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
        camTrans.position = lookAt.position + rotation * dir;
        camTrans.LookAt(lookAt.position);
    }
}
