using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public int heartNumber;
    private float scrollSpeed = 0.1f;
    private float decreaseInterval = 30f; // Decrease interval in seconds
    private TextMeshProUGUI heartNumberUi;
    private string heartNumberKey = "Heart";

    // DecreaseHeartCount();
    private void Start()
    {

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
        slider.value = CalculateSliderValue();
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
        SaveHeartNumber();
        UpdateUI();

    }
    public void DecreaseHeart()
    {
        
        heartNumber--;
        SaveHeartNumber();
        UpdateUI();

    }

    private void SaveHeartNumber()
    {
        PlayerPrefs.SetInt(heartNumberKey, heartNumber);
    }

    private void UpdateUI()
    {
        // Debug.Log(slider.value);
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
                // Debug.Log("Pre Decrease heart num: "+heartNumber);
                heartNumber--;
                // Debug.Log("Decreased heart num: "+heartNumber);
                SaveHeartNumber(); // Save heart number to PlayerPrefs
                UpdateUI();
                
            }
        }
    }
}
