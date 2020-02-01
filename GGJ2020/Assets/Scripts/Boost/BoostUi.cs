using UnityEngine;
using UnityEngine.UI;
public class BoostUi : MonoBehaviour
{
    [SerializeField] private Float nbrBoost=null ;
    [SerializeField] private Image BoostFiller = null;
    [SerializeField] private Float maxBoost=null ;

    // Update is called once per frame
    void Update()
    {
        BoostFiller.fillAmount = nbrBoost.value / maxBoost.value;
    }
}
