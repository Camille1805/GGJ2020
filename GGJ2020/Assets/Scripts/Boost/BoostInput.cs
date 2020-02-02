using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostInput : MonoBehaviour
{
    [SerializeField]
    Float boost = null;
    [SerializeField]
    BoolValue isBoosted = null;
    bool isTrigered;
    [SerializeField]
    TrailRenderer trail = null;
    [SerializeField] AudioSource audioSource = null;
    [SerializeField] private float volumeModifier = 1.0f;
    float volume = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        boost.value = 1000;
    }

    // Update is called once per frame
    void Update()
    {
        isBoosted.value = false;
        isTrigered = false;
        if (Input.GetAxis("BOOST") != 0)
        {
            isTrigered = true;
        }
        if (isTrigered && boost.value > 0)
        {
           boost.value--;
           isBoosted.value = true;
           volume = Mathf.Clamp(volume + 0.1f, 0f, 1.0f);
        }
        else
        {
            volume = Mathf.Clamp(volume - 0.05f, 0f, 1.0f);
        }
        volume *= volumeModifier;
        trail.emitting = isBoosted.value;
        audioSource.volume = volume;
    }

}
