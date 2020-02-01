using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Float", menuName = "Float", order = 0)]
public class Float : ScriptableObject
{
    public float value;

    public static implicit operator Float(float v)
    {
        throw new NotImplementedException();
    }
}
