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
<<<<<<< HEAD
           boost.value--;
           isBoosted.value = true;
           //Debug.Log("Le joueur utilise son boost !");
=======
            boost.value--;
            isBoosted.value = true;
            volume = Mathf.Clamp(volume + 0.1f, 0f, 1.0f);
>>>>>>> e6419b52c7f4979af169d903af28d963b71b1d0e
        }
        else
        {
            volume = Mathf.Clamp(volume - 0.05f, 0f, 1.0f);
        }
        volume *= volumeModifier;
        Debug.Log(volume);
        trail.emitting = isBoosted.value;
        audioSource.volume = volume;
    }

}
