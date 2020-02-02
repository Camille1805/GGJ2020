using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMaterial : MonoBehaviour
{
    public Material material;
    public Material material2;
    public float value;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        material.color = new Color(material.color.r, material.color.g, material.color.b,1-value);
        material2.color = new Color(material.color.r, material.color.g, material.color.b, value);
    }
}
