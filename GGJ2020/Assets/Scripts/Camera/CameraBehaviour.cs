using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    public Transform startTarget;
    public Transform target;
    public float rotationSpeedModifier = 1.0f;

    private bool isFirstUpdate = true;

    void Update()
    {
        if (isFirstUpdate)
        {
            isFirstUpdate = false;
            transform.rotation = Quaternion.LookRotation(startTarget.position - transform.position);
        }
        //transform.LookAt(target);

        var targetRotation = Quaternion.LookRotation(target.position - transform.position);

        // Smoothly rotate towards the target point.
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeedModifier * Time.deltaTime);
    }
}
