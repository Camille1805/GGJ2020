using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleScript : MonoBehaviour
{
    public Image image;
    // Start is called before the first frame update

    IEnumerator FadeOutAfter(float time)
    {
        yield return new WaitForSeconds(time);
        image.CrossFadeAlpha(0, 2, true);
        // Code to execute after the delay
    }

    void Start()
    {
        StartCoroutine(FadeOutAfter(3));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
