using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurfControl : MonoBehaviour
{
    [SerializeField] private float thrust = 10.0f;
    [SerializeField] private ForceMode forwardForceMode = ForceMode.Impulse;
    [SerializeField] private float rotationForce = 25.0f;
    [SerializeField] private Rigidbody rigidBody;
    [SerializeField] private bool showDebug = false;
    [SerializeField] BoolValue isBoosted;
    private InputManager inputManager;
    [SerializeField] float forceBonusValue = 10;
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        inputManager = GetComponent<InputManager>();
    }

    void FixedUpdate()
    {
        Vector2 directions = inputManager.getAxesValues();
        this.MoveForward(directions.y);
        this.RotateSurf(directions);
    }

    private void MoveForward(float yAxisValue)
    {
        float forwardForce;
        if(isBoosted.value)
            forwardForce = thrust * yAxisValue +forceBonusValue;
        else
            forwardForce = thrust * yAxisValue;
        rigidBody.AddForce(transform.forward * forwardForce, forwardForceMode);
        if (showDebug)
        {
            Debug.Log("forward" + transform.forward);
        }
    }

    private void RotateSurf(Vector2 directions)
    {
        Vector3 localEulerAngles = transform.localEulerAngles;
        localEulerAngles.y += directions.x * rotationForce;
        Quaternion eulerRot = Quaternion.Euler(localEulerAngles);
        transform.rotation = Quaternion.Slerp(transform.rotation, eulerRot, Time.deltaTime * 10);
        if (showDebug)
        {
            Debug.Log("eulerRot: " + eulerRot + ", directions.x: " + directions.x);
        }
    }
}
