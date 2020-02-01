using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boost : MonoBehaviour
{
    [SerializeField]
    Vector2 vecteurBoost;
    [SerializeField]
    float quantiteeEnPlus;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            //TODO get component player pour add boost;
        }
    }

}
