using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurfControl : MonoBehaviour
{
    public float thrust;
    public Rigidbody rigidBody;
    private InputManager inputManager;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        inputManager = GetComponent<InputManager>();
    }

    void FixedUpdate()
    {
        rigidBody.AddForce(transform.forward * thrust);
        Debug.Log("directions: " + inputManager.getAxesValues());
    }
}
