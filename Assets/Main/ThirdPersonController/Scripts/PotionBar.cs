using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PotionBar : MonoBehaviour
{
    public Slider slider;
    public TextMeshProUGUI BarText;

    void Start()
    {
        // Set initial value of the slider to 0
        slider.value = 0;
        UpdateBarText(); // Update text on start
    }

    void Update()
    {
         UpdateBarText();
    }

    public void FillSpellBar(){
        slider.value = 3;
    }

    public void ReduceSpellBar(){
        if (slider.value > 0)
            {
                slider.value -= 1;
            }
    }

    void UpdateBarText()
    {
        BarText.text = slider.value.ToString();
    }
    
}
