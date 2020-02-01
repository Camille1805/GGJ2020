using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostInput : MonoBehaviour
{
    [SerializeField]
    Float boost;
    [SerializeField]
    BoolValue isBoosted;
    bool isTrigered;
    [SerializeField]
    TrailRenderer trail;
    // Start is called before the first frame update
    void Start()
    {
        boost.value = 1000;
    }

    // Update is called once per frame
    void Update()
    {
        isBoosted.value=false;
        isTrigered = false;
        if (Input.GetAxis("BOOST") != 0)
        {
            isTrigered = true;
        }
        if (isTrigered && boost.value > 0) 
        {
           boost.value--;
           isBoosted.value = true;
           Debug.Log("Le joueur utilise son boost !");
        }
        trail.emitting = isBoosted.value;
    }

}
