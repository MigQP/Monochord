using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SphereManager : MonoBehaviour
{
    public PlayerInput _playerInput;

    public float speed = 1;

    public float degree;

    bool xLeft_isRotating;
    bool xRight_isRotating;

    public Rigidbody rb;


    void Start()
    {
        _playerInput = GetComponent<PlayerInput>();
        _playerInput.actions["Move"].performed += ReadInput;
        _playerInput.actions["Move"].canceled += ReadInput;

    }

    void ReadInput(InputAction.CallbackContext context)
    {
        //Debug.Log(context.ReadValue<Vector2>());
        if(context.ReadValue<Vector2>().x < 0)
        {
            xLeft_isRotating = true;
        }
        if(context.ReadValue<Vector2>().x == 0)
        {
            xLeft_isRotating = false;
            xRight_isRotating = false;
            rb.isKinematic = true;
        }
        if (context.ReadValue<Vector2>().x > 0)
        {
            xRight_isRotating = true;
        }


    }

    void Update()
    {

        if (xLeft_isRotating)
        {
            rb.isKinematic = false;
            //transform.Rotate(Vector3.forward * speed, Space.Self);
            Vector3 rotationAxis = transform.forward * speed;
            rb.AddTorque(rotationAxis);
            float z = rb.angularVelocity.z;
            //Debug.Log(Mathf.Abs(z));
        }

        if (xRight_isRotating)
        {
            rb.isKinematic = false;
            //transform.Rotate(Vector3.back * speed, Space.Self);
            Vector3 rotationAxis = -transform.forward * speed;
            rb.AddTorque(rotationAxis);
            float z = rb.angularVelocity.z;
            //Debug.Log(Mathf.Abs(z));
        }
    }

    public void SetRotationInput(Vector3 rotation)
    {
        transform.Rotate(rotation, Space.World);

    }


    void OldRotate()
    {
        // Rotate by certain degreees

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            SetRotationInput(new Vector3(degree, 0, 0));
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            SetRotationInput(new Vector3(-degree, 0, 0));
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            SetRotationInput(new Vector3(0, 0, degree));
       
        }

        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            SetRotationInput(new Vector3(0, 0, -degree));
        }
    }
}
