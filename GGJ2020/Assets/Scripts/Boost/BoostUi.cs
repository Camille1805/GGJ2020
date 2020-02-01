using UnityEngine;
using UnityEngine.UI;
public class BoostUi : MonoBehaviour
{
    [SerializeField] private Float nbrBoost = 1.0f;
    [SerializeField] private Image BoostFiller = null;
    [SerializeField] private Float maxBoost = 1.0f;

    // Update is called once per frame
    void Update()
    {
        BoostFiller.fillAmount = nbrBoost.value / maxBoost.value;
    }
}
