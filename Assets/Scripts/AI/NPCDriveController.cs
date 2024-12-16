using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDriveController : MonoBehaviour
{
    private float horizontalInput, verticalInput;
    private float currentSteerAngle, currentbreakForce;
    private bool isBreaking;

    // Settings
    [SerializeField] private float motorForce, breakForce, maxSteerAngle;
    [SerializeField] private float maxSpeed = 20f; // Límite de velocidad en unidades por segundo

    // Wheel Colliders
    [SerializeField] private WheelCollider frontLeftWheelCollider, frontRightWheelCollider;
    [SerializeField] private WheelCollider rearLeftWheelCollider, rearRightWheelCollider;

    // Wheels
    [SerializeField] private Transform frontLeftWheelTransform, frontRightWheelTransform;
    [SerializeField] private Transform rearLeftWheelTransform, rearRightWheelTransform;

    private Rigidbody rb;

    private void Awake()
    {
        // Obtener el componente Rigidbody para medir la velocidad
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        HandleMotor();
        HandleSteering();
        UpdateWheels();
    }

    public void SetInputs(float horizontal, float vertical, bool braking)
    {
        horizontalInput = horizontal;
        verticalInput = vertical;
        isBreaking = braking;
    }

    private void HandleMotor()
    {
        // Calcular la velocidad actual del vehículo en unidades por segundo
        float currentSpeed = rb.linearVelocity.magnitude;

        // Reducir la fuerza del motor si se excede el límite de velocidad
        float adjustedMotorForce = currentSpeed > maxSpeed ? 0f : motorForce;

        // Aplicar la fuerza del motor ajustada solo si se está acelerando
        if (verticalInput > 0)
        {
            frontLeftWheelCollider.motorTorque = verticalInput * adjustedMotorForce;
            frontRightWheelCollider.motorTorque = verticalInput * adjustedMotorForce;
        }
        else
        {
            // Si no se está acelerando, aplica frenado automáticamente
            isBreaking = true;
        }

        // Aplicar el freno
        currentbreakForce = isBreaking ? breakForce : 0f;
        ApplyBreaking();
    }

    private void ApplyBreaking()
    {
        frontRightWheelCollider.brakeTorque = currentbreakForce;
        frontLeftWheelCollider.brakeTorque = currentbreakForce;
        rearLeftWheelCollider.brakeTorque = currentbreakForce;
        rearRightWheelCollider.brakeTorque = currentbreakForce;
    }

    private void HandleSteering()
    {
        currentSteerAngle = maxSteerAngle * horizontalInput;
        frontLeftWheelCollider.steerAngle = currentSteerAngle;
        frontRightWheelCollider.steerAngle = currentSteerAngle;
    }

    private void UpdateWheels()
    {
        UpdateSingleWheel(frontLeftWheelCollider, frontLeftWheelTransform);
        UpdateSingleWheel(frontRightWheelCollider, frontRightWheelTransform);
        UpdateSingleWheel(rearRightWheelCollider, rearRightWheelTransform);
        UpdateSingleWheel(rearLeftWheelCollider, rearLeftWheelTransform);
    }

    private void UpdateSingleWheel(WheelCollider wheelCollider, Transform wheelTransform)
    {
        Vector3 pos;
        Quaternion rot;
        wheelCollider.GetWorldPose(out pos, out rot);
        wheelTransform.rotation = rot;
        wheelTransform.position = pos;
    }
}
