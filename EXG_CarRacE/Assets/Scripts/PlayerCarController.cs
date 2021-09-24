using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCarController : MonoBehaviour
{

    private float horizontalInput;
    private float verticalInput;
    private float steerAngle;
    private float currentSteerAngle;
    private float curSpeed =0;


    [SerializeField] private float motorForce;
    [SerializeField] private float maxSteerAngle;
    [SerializeField] private float forwardAccel;

    [SerializeField] private WheelCollider frontLeftWheelCollider;
    [SerializeField] private WheelCollider frontRightWheelCollider;
    [SerializeField] private WheelCollider backLeftWheelCollider;
    [SerializeField] private WheelCollider backRightWheelCollider;


    [SerializeField] private Transform frontLeftWheelTransform;
    [SerializeField] private Transform frontRightWheelTransform;
    [SerializeField] private Transform backLeftWheelTransform;
    [SerializeField] private Transform backRightWheelTransform;

    public ParticleSystem[] dustTrail;
    public float maxEmission = 25f;
    private float emissionRate;

    // Update is called once per frame
    void FixedUpdate()
    {
        GetInput();
        HandleMotor();
        HandleSteering();
        UpdateWheels();
        SmokeEmission();
    }

    private void HandleMotor()
    {
        frontLeftWheelCollider.motorTorque = verticalInput;
        frontRightWheelCollider.motorTorque = verticalInput;
    }

    private void HandleSteering()
    {
        currentSteerAngle = maxSteerAngle * horizontalInput;
        frontLeftWheelCollider.steerAngle = currentSteerAngle;
        frontRightWheelCollider.steerAngle = currentSteerAngle;
    }
    private void GetInput()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = curSpeed;

        curSpeed += forwardAccel * Time.deltaTime;


        if (curSpeed > motorForce)
            curSpeed = motorForce;
    }   

    private void UpdateWheels()
    {
        UpdateSingleWheel(frontLeftWheelCollider, frontLeftWheelTransform);
        UpdateSingleWheel(frontRightWheelCollider, frontRightWheelTransform);
        UpdateSingleWheel(backLeftWheelCollider, backLeftWheelTransform);
        UpdateSingleWheel(backRightWheelCollider, backRightWheelTransform);
    }
     
    private void UpdateSingleWheel(WheelCollider wheelCollider, Transform wheelTransform)
    {
        Vector3 pos;
        Quaternion rot;
        wheelCollider.GetWorldPose(out pos, out rot);
        wheelTransform.rotation = rot;
        wheelTransform.position = pos; 

    }

    private void SmokeEmission()
    {
        foreach (ParticleSystem partS in dustTrail)
        {
            var emissionModule = partS.emission;
            emissionModule.rateOverTime = emissionRate;
        }
    }
}
