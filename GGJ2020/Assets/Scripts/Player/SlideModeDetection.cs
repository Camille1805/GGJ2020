using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideModeDetection : MonoBehaviour
{
    public GameObject surf;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("SlideLimite"))
        {
            Debug.Log("Slide mode");
            surf.GetComponent<SlidPathFollow>().enabled = true;
        };
    }
}
