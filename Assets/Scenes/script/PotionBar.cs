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
        // Check for key press to increase slider value to 3
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            slider.value = 3;
        }
        // Check for key press to decrease slider value by 1
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            // Ensure slider value does not go below 0
            if (slider.value > 0)
            {
                slider.value -= 1;
            }
        }

         UpdateBarText();
    }

    // Method to update the text value of the slider
    void UpdateBarText()
    {
        BarText.text = slider.value.ToString();
    }

    // Call this method whenever the slider value changes (e.g., through dragging)
    
}
