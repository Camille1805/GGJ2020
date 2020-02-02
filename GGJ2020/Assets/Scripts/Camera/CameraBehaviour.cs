using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    public Transform target;
    public float rotationSpeedModifier = 1.0f;

    void Update()
    {
        //transform.LookAt(target);

        var targetRotation = Quaternion.LookRotation(target.position - transform.position);

        // Smoothly rotate towards the target point.
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeedModifier * Time.deltaTime);
    }
}
