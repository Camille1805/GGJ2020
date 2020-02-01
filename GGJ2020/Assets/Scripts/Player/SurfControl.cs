using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurfControl : MonoBehaviour
{
    [SerializeField] private float thrust;
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
        float forwardForce = thrust * directions.y;
        Debug.Log("forwardForce" + forwardForce + ", directionY" + directions.y);
        rigidBody.AddForce(transform.forward * forwardForce);
        transform.eulerAngles = new Vector3(0, Mathf.Atan2(directions.y, directions.x) * 180 / Mathf.PI, 0);
    }
}
