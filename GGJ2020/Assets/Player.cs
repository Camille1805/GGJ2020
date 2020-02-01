using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    Float boost;
    [SerializeField]
    BoolValue isBoosted;
    // Start is called before the first frame update
    void Start()
    {
        boost.value = 1000;
    }

    // Update is called once per frame
    void Update()
    {
        isBoosted.value=false;
        if (Input.GetButton("BOOST") && boost.value > 0) 
        {
           boost.value--;
           isBoosted.value = true;    
        }
        Debug.Log("Le joueur utilise sont boost: " + isBoosted.value);
    }
    void MoveMovement()
    {
        //TODO ajouter boost si boost.value=true ;
    }
}
