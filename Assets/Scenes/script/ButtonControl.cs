using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonControl : MonoBehaviour
{
    public Button button;
    public Slider slider;
    public TextMeshProUGUI heartNumberUi;

    private int heartNumber = 2; // Default heart number
    private float scrollSpeed = 0.1f;
    private float decreaseInterval = 10f; // Decrease interval in seconds

    private void Start()
    {  
        // Load the saved heartNumber value from PlayerPrefs
        if (PlayerPrefs.HasKey("Heart"))
        {
            heartNumber = PlayerPrefs.GetInt("Heart");
        }

        // Add listener for button click event
        button.onClick.AddListener(OnButtonClick);
        
        // Start the coroutine to decrease heart count
        StartCoroutine(DecreaseHeartCount());

        // Set the initial heart number text
        heartNumberUi.text = heartNumber.ToString();
    }

    private void OnDestroy()
    {
        // Remove listener for button click event
        button.onClick.RemoveListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        // Increase heart number when the button is clicked
        heartNumber++;
        PlayerPrefs.SetInt("Heart", heartNumber); // Save heart number to PlayerPrefs

        // Update UI
        UpdateUI();
    }

    private void UpdateUI()
    {
        // Update slider value
        slider.value = CalculateSliderValue();

        // Update heart number text
        heartNumberUi.text = heartNumber.ToString();
    }

    private float CalculateSliderValue()
    {
        // Calculate the value based on the heart number
        float newValue = heartNumber * scrollSpeed;
        return Mathf.Clamp(newValue, slider.minValue, slider.maxValue); 
    }

    private System.Collections.IEnumerator DecreaseHeartCount()
    {
        while (true)
        {
            yield return new WaitForSeconds(decreaseInterval);

            // Decrease the heart number
            heartNumber--;

            // Save heart number to PlayerPrefs
            PlayerPrefs.SetInt("Heart", heartNumber);

            // Update UI
            UpdateUI();

            // Check if heartNumber is zero
            if (heartNumber <= 0)
            {
                // Load the home screen scene
                SceneManager.LoadScene("HomePage");
            }
        }
    }
}
