using UnityEngine;
using UnityEngine.UI;

public class SliderScripts : MonoBehaviour
{

    private void Start()
    {
        FillSlider();
    }

    public void FillSlider()
    {
        gameObject.transform.GetChild(1).GetChild(0).GetComponent<Image>().fillAmount = gameObject.GetComponent<Slider>().value;
    }
}
