using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Car : MonoBehaviour
{
    public Rigidbody rb;
    public WheelCollider wheel1, wheel2, wheel3, wheel4;
    public float driveSpeed, steerSpeed;
    private float horizontalInput, verticalInput;
    private float motor;

    void Awake()
    {
        if(rb == null)
        {
            rb = GetComponent<Rigidbody>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
    }

    void FixedUpdate()
    {
        motor = Input.GetAxis("Vertical") * driveSpeed;
        wheel1.motorTorque = motor;
        wheel2.motorTorque = motor;
        wheel3.motorTorque = motor;
        wheel4.motorTorque = motor;

        wheel1.steerAngle = steerSpeed * horizontalInput;
        wheel2.steerAngle = steerSpeed * horizontalInput;
    }
}
