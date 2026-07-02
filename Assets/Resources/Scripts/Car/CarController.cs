using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CarController : MonoBehaviour
{
    [Header("Forces")]
    public float motorForce;
    public float brakeForce;
    public float maxSteerAngle;

    [Header("Colliders")]
    public WheelCollider FrontLeftWheelCollider;
    public WheelCollider FrontRightWheelCollider;
    public WheelCollider BackLeftWheelCollider;
    public WheelCollider BackRightWheelCollider;

    [Header("Transforms")]
    public Transform FrontLeftWheelTransform;
    public Transform FrontRightWheelTransform;
    public Transform BackLeftWheelTransform;
    public Transform BackRightWheelTransform;

    [Header("Dynamic Forces")]
    public float horizontalInput;
    public float verticalInput;
    public float currentSteerAngle;
    public float currentBrakeForce;
    public bool isBraking;

    void Awake()
    {
        motorForce = 100f;
        brakeForce = 1000f;
        maxSteerAngle = 30f;
    }

    private void Update()
    {
        GetInput();
        HandleMotor();
        HandleSteering();
        UpdateWheels();
    }

    private void GetInput()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        // Debug.Log("HorizontalInput: " + horizontalInput);
        verticalInput = Input.GetAxis("Vertical");
        // Debug.Log("VerticalInput: " + verticalInput);
        isBraking = Input.GetKey(KeyCode.Space);
    }
    
    private void HandleMotor()
    {
        FrontLeftWheelCollider.motorTorque = verticalInput * motorForce;
        FrontRightWheelCollider.motorTorque = verticalInput * motorForce;

        currentBrakeForce = isBraking? brakeForce : 0f;
        ApplyBraking();
    }

    private void ApplyBraking()
    {
        FrontLeftWheelCollider.brakeTorque = currentBrakeForce;
        FrontRightWheelCollider.brakeTorque = currentBrakeForce;
        BackLeftWheelCollider.brakeTorque = currentBrakeForce;
        BackRightWheelCollider.brakeTorque = currentBrakeForce;
    }

    private void HandleSteering()
    {
        currentSteerAngle = maxSteerAngle * horizontalInput;
        FrontLeftWheelCollider.steerAngle = currentSteerAngle;
        FrontRightWheelCollider.steerAngle = currentSteerAngle;
    }

    private void UpdateSingleWheel(WheelCollider wheelCollider, Transform wheelTransform)
    {
        Vector3 position;
        Quaternion rotation;
        wheelCollider.GetWorldPose(out position, out rotation);
        wheelTransform.position = position;
        wheelTransform.rotation = rotation;
    }

    private void UpdateWheels()
    {
        UpdateSingleWheel(FrontLeftWheelCollider, FrontLeftWheelTransform);
        UpdateSingleWheel(FrontRightWheelCollider, FrontRightWheelTransform);
        UpdateSingleWheel(BackLeftWheelCollider, BackLeftWheelTransform);
        UpdateSingleWheel(BackRightWheelCollider, BackRightWheelTransform);
    }
}