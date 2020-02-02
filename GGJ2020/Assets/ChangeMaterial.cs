using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMaterial : MonoBehaviour
{
    public Renderer material;
    public float value;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        value = Mathf.Clamp(value, 0f, 1f);
        material.material.color= new Color(1f,1f, (255 - 255 * value)/255f, 1);

    }
}
