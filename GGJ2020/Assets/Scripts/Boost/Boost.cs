using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boost : MonoBehaviour
{

    [SerializeField]
    float quantiteeEnPlus=0;
    [SerializeField]
    Float boostDuJoueur = null;
    [SerializeField]
    Float boostMaxJoueur=null;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            boostDuJoueur.value += Mathf.Clamp(quantiteeEnPlus, 0, boostMaxJoueur.value);
            Destroy(gameObject);
;        }
    }

}
