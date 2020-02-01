using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class BoostUi : MonoBehaviour
{
    [SerializeField]
    Float nbrBoost;
    [SerializeField]
    Image BoostFiller;
    [SerializeField]
    Float maxBoost;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        BoostFiller.fillAmount = nbrBoost.value / maxBoost.value;
    }
}
