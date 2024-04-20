using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    private int heartNumber = 2;
    private float scrollSpeed = 0.1f;
    private float decreaseInterval = 10f; // Decrease interval in seconds
    public TextMeshProUGUI heartNumberUi;

    private void Start()
    {
        StartCoroutine(DecreaseHeartCount());
        // heartNumberUi.text = heartNumber.ToString();
    }

    private void Update()
    {
        // if (Input.GetKeyDown(KeyCode.E))
        // {
        //     IncreaseHeartCount();
        // }
    }

    public void IncreaseHeartCount()
    {
        heartNumber++;
        slider.value = CalculateSliderValue();
        heartNumberUi.text = heartNumber.ToString();
    }

    private void OnButtonClick()
    {
        heartNumber++;
        slider.value = CalculateSliderValue();
        heartNumberUi.text = heartNumber.ToString();
        // Deactivate the object when button is clicked
        // objectToActivate.SetActive(false);

        // Set the button as uninteractable after click
        // button.interactable = false;
    }

    private float CalculateSliderValue()
    {
        // Calculate the value based on the heart number
        float newValue = heartNumber * scrollSpeed;
        return Mathf.Clamp(newValue, slider.minValue, slider.maxValue);
    }

    private IEnumerator DecreaseHeartCount()
    {
        while (true)
        {
            yield return new WaitForSeconds(decreaseInterval);

            // Decrease the heart number
            if(heartNumber>0){
                heartNumber--;
            }
            // heartNumber--;

            // Adjust the value of the slider
            slider.value = CalculateSliderValue();
            heartNumberUi.text = heartNumber.ToString();
        }
    }
}
