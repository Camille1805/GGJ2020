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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            boostDuJoueur.value += Mathf.Clamp(quantiteeEnPlus, 0, boostMaxJoueur.value);
            Destroy(gameObject);
;        }
    }

}
