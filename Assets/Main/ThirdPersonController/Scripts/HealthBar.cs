using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    private int heartNumber = 3;
    private float scrollSpeed = 0.1f;
    private float decreaseInterval = 40f; // Decrease interval in seconds
    private TextMeshProUGUI heartNumberUi;
    private string heartNumberKey = "Heart";

    private void Start()
    {
        // Load heart number from PlayerPrefs if it exists
        // if (PlayerPrefs.GetInt(heartNumberKey) > 0)
        // {
        //     heartNumber = PlayerPrefs.GetInt(heartNumberKey);
        // }

        StartCoroutine(DecreaseHeartCount());
        GameObject healthNumTextObject = GameObject.FindGameObjectWithTag("HeartNumText");
        if (healthNumTextObject != null)
        {
            heartNumberUi = healthNumTextObject.GetComponent<TextMeshProUGUI>();
            heartNumberUi.text = heartNumber.ToString();
        }
        else
        {
            Debug.LogWarning("TextMeshProUGUI object not found with the tag 'HealthNumText'. Make sure it's tagged correctly.");
        }
    }

    private void Update()
    {
        if (heartNumber == 0)
        {
            SceneManager.LoadScene("GameOver");
        }

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
        Debug.Log(slider.value);
        slider.value = CalculateSliderValue();
        if (heartNumberUi != null)
        {
            heartNumberUi.text = heartNumber.ToString();
            // Canvas.ForceUpdateCanvases();
        }
        else
        {
            Debug.LogWarning("TextMeshProUGUI object not found. Cannot update UI.");
        }
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
