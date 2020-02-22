using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    static AudioManager am=null;
    // Start is called before the first frame update
    void Start()
    {
        if (am != null) {
            Destroy(gameObject);
        }
        else
        {
            Debug.Log("ldldkd");
            am = this;
            DontDestroyOnLoad(gameObject);
            GetComponent<AudioSource>().Play();
        }
    }

}
