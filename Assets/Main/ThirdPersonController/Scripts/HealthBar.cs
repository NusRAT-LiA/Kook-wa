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
    private float decreaseInterval = 5f; // Decrease interval in seconds
    public TextMeshProUGUI heartNumberUi;
    private string heartNumberKey = "Heart";

    private void Start()
    {
        // Load heart number from PlayerPrefs if it exists
        if (PlayerPrefs.HasKey(heartNumberKey))
        {
            heartNumber = PlayerPrefs.GetInt(heartNumberKey);
        }

        StartCoroutine(DecreaseHeartCount());
        heartNumberUi.text = heartNumber.ToString();
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
        SaveHeartNumber(); // Save heart number to PlayerPrefs
        UpdateUI();
    }

    private void SaveHeartNumber()
    {
        PlayerPrefs.SetInt(heartNumberKey, heartNumber);
    }

    private void UpdateUI()
    {
        slider.value = CalculateSliderValue();
        heartNumberUi.text = heartNumber.ToString();
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
            if (heartNumber > 0)
            {
                heartNumber--;
                SaveHeartNumber(); // Save heart number to PlayerPrefs
                UpdateUI();
            }
        }
    }
}
