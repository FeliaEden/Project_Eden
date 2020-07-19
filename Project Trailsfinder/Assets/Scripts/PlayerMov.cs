using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMov : MonoBehaviour
{
    public Rigidbody rb;
    private float forwardForce = 10f;
    private Camera cam;
    private CharacterController charContr;
    private Transform camTransform;
    private float inputX, inputZ, speeD;

    private Vector3 desiredMoveDir;

    [SerializeField] float rotationSpeed = 0.3f;
    [SerializeField] float allowRot = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        charContr = GetComponent<CharacterController>();
        cam = Camera.main;
    }


    // On Update per frame, cube moves
    void FixedUpdate()
    {

        inputX = Input.GetAxis("Horizontal");
        inputZ = Input.GetAxis("Vertical");

        InputDecider();
        
        // Key Inputs
        if (Input.GetKey("w"))
        {
            transform.Translate(0f, 0f, forwardForce * Time.deltaTime);
        }
        else if (Input.GetKey("d"))
        {
            transform.Translate(0f, 0f, forwardForce * Time.deltaTime);
        }
        else if (Input.GetKey("a"))
        {

            transform.Translate(0f, 0f, forwardForce * Time.deltaTime);
        }
        else if (Input.GetKey("s"))
        {
            transform.Translate(0f, 0f, forwardForce * Time.deltaTime);
        }


        
    }

    void InputDecider()
    {
        speeD = new Vector2(inputX, inputZ).sqrMagnitude;
        if(speeD > allowRot)
        {
            MovementManager();
        }

    }

    void MovementManager()
    {


        var camForward = cam.transform.forward;
        var camRight = cam.transform.right;

        camForward.y = 0;
        camRight.y = 0;

        camForward.Normalize();
        camRight.Normalize();

        desiredMoveDir = camForward * inputZ + camRight * inputX;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(desiredMoveDir), rotationSpeed);
    }

}
