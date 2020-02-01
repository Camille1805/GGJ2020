
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputManager : MonoBehaviour
{

    private float xAxisValue;
    private float yAxisValue;


    // Use this for initialization
    void Start()
    {}

    // Update is called once per frame
    void Update()
    {
        xAxisValue = Input.GetAxis("Horizontal");
        yAxisValue = Input.GetAxis("Vertical");
    }


    public Vector2 getAxesValues()
    {
        return new Vector2(xAxisValue, yAxisValue);
    }
}