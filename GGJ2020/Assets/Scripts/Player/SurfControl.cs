using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurfControl : MonoBehaviour
{
    [SerializeField] private float thrust;
    [SerializeField] private ForceMode forwardForceMode;
    [SerializeField] private float rotationForce;
    [SerializeField] private Rigidbody rigidBody;
    private InputManager inputManager;

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
        float forwardForce = thrust * yAxisValue;
        rigidBody.AddForce(transform.forward * forwardForce, forwardForceMode);
        // Debug.Log("forwardForce" + forwardForce + ", directionY" + yAxisValue);
    }

    private void RotateSurf(Vector2 directions)
    {
        Vector3 eulerAngles = transform.eulerAngles;
        eulerAngles.y += directions.x * rotationForce;
        Quaternion eulerRot = Quaternion.Euler(eulerAngles);
        transform.rotation = Quaternion.Slerp(transform.rotation, eulerRot, Time.deltaTime * 10);
        Debug.Log(eulerRot + " " + directions.x);
    }
}
