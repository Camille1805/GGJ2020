using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTransitioner : MonoBehaviour
{

    [SerializeField] private Transform[] views;
    [SerializeField] private Transform currentView;
    [SerializeField] private float transitionSpeed;

    void Update()
    {

        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("view0");
            currentView = views[0];
        }

        if (Input.GetButtonDown("Fire2"))
        {
            Debug.Log("view0");
            currentView = views[1];
        }
    }


    void LateUpdate()
    {
        Vector3 distanceToTravel = transform.position - currentView.position;
        if (distanceToTravel == Vector3.zero)
        {
            return;
        }
        Debug.Log("Moving camera" + distanceToTravel);
        transform.position = Vector3.Lerp(transform.position, currentView.position, Time.deltaTime * transitionSpeed);
        Vector3 currentAngle = new Vector3(
         Mathf.LerpAngle(transform.rotation.eulerAngles.x, currentView.transform.rotation.eulerAngles.x, Time.deltaTime * transitionSpeed),
         Mathf.LerpAngle(transform.rotation.eulerAngles.y, currentView.transform.rotation.eulerAngles.y, Time.deltaTime * transitionSpeed),
         Mathf.LerpAngle(transform.rotation.eulerAngles.z, currentView.transform.rotation.eulerAngles.z, Time.deltaTime * transitionSpeed));
        transform.eulerAngles = currentAngle;
    }
}
