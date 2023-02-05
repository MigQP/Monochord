using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class SphereManager : MonoBehaviour
{
    public PlayerInput _playerInput;

    public float speed = 1;

    public float degree;

    bool xLeft_isRotating;
    bool xRight_isRotating;

    public Rigidbody rb;

    public float angleSpeed;
    public float maxAngleSpeed;

    public string note;
    public TMP_Text textNote;

    public float dir;

    Tuner tuner;
    void Start()
    {
        _playerInput = GetComponent<PlayerInput>();
        _playerInput.actions["Move"].performed += ReadInput;
        _playerInput.actions["Move"].canceled += ReadInput;

        tuner = FindObjectOfType<Tuner>();
    }

    void ReadInput(InputAction.CallbackContext context)
    {
        //Debug.Log(context.ReadValue<Vector2>().x);
        if(context.ReadValue<Vector2>().x < 0)
        {
            xLeft_isRotating = true;

            //tuner.modification = 0;
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
       
        textNote.text = note;

        if (xLeft_isRotating)
        {
            rb.isKinematic = false;
            //transform.Rotate(Vector3.forward * speed, Space.Self);
            Vector3 rotationAxis = transform.forward * speed;
            rb.AddTorque(rotationAxis);
            float z = rb.angularVelocity.z;
            //Debug.Log(Mathf.Abs(z));
            dir -= .01f;
        }

        if (xRight_isRotating)
        {
            rb.isKinematic = false;
            //transform.Rotate(Vector3.back * speed, Space.Self);
            Vector3 rotationAxis = -transform.forward * speed;
            rb.AddTorque(rotationAxis);
            float z = rb.angularVelocity.z;
            //Debug.Log(Mathf.Abs(z));
            dir += .01f;
        }
        
        angleSpeed = rb.angularVelocity.z;
        //Debug.Log(Mathf.Abs(z1));
        //Debug.Log(transform.rotation.z);


        if (transform.eulerAngles.z == 210 || transform.eulerAngles.z < 220 && transform.eulerAngles.z > 200)
        {
            note = "B";

        }

        if (transform.eulerAngles.z == 240 || transform.eulerAngles.z < 250 && transform.eulerAngles.z > 230)
        {
            note = "C";
        }

        if (transform.eulerAngles.z == 270 || transform.eulerAngles.z < 280 && transform.eulerAngles.z > 260)
        {
            note = "D";
        }

        if (transform.eulerAngles.z == 300 || transform.eulerAngles.z < 310 && transform.eulerAngles.z > 290)
        {
            note = "F";
        }

        if (transform.eulerAngles.z == 330 || transform.eulerAngles.z < 340 && transform.eulerAngles.z > 320)
        {
            note = "G";
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

    public float AlphaFromRotation()
    {
        return angleSpeed / maxAngleSpeed;
    }
    
    public void DoTorque()
    {
        Vector3 rotationAxis = transform.forward * speed;
        rb.AddTorque(rotationAxis);
        rb.isKinematic = false;
    }
}
