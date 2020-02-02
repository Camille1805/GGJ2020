using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMaterial : MonoBehaviour
{
    public Renderer material;
    public Renderer material2;
    public int value;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        material.material.renderQueue = value;
        // material.material.color = new Color(material.material.color.r, material.material.color.g, material.material.color.b,1-value);
      //  material2.material.color = new Color(material.material.color.r, material.material.color.g, material.material.color.b, value);
    }
}
