using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boost : MonoBehaviour
{

    [SerializeField]
    float quantiteeEnPlus;
    [SerializeField]
    Float boostDuJoueur;
    [SerializeField]
    Float boostMaxJoueur;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("");
        if (other.tag.Equals("Player"))
        {
            boostDuJoueur.value += Mathf.Clamp(quantiteeEnPlus, 0, boostMaxJoueur.value);
            Destroy(gameObject);
;        }
    }

}
