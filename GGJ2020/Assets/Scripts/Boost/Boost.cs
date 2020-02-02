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
    [SerializeField]
    float time=10f;
    IEnumerator wait()
    {
        yield return new WaitForSeconds(time);
        GetComponent<MeshRenderer>().enabled = true;
        GetComponent<SphereCollider>().enabled = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            boostDuJoueur.value = Mathf.Clamp(boostDuJoueur.value+quantiteeEnPlus, 0, boostMaxJoueur.value);
            GetComponent<MeshRenderer>().enabled=false;
            GetComponent<SphereCollider>().enabled = false;
            StartCoroutine(wait());
;        }
    }

}
