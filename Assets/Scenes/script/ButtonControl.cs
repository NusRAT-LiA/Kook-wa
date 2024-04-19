using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonControl : MonoBehaviour
{
    // public GameObject objectToActivate;
    public Button button;

    public Slider slider;
    private int heartNumber = 0;
    private float scrollSpeed = 0.1f;
    private float decreaseInterval = 10f; // Decrease interval in seconds
    public TextMeshProUGUI heartNumberUi;

    private void Start()
    {
        // Deactivate the button initially
        // objectToActivate.SetActive(false);

        // Subscribe to the static collision event
        MovingObject.OnCollisionEventStatic += OnCollisionEventTriggered;

        // Add listener for button click event
        button.onClick.AddListener(OnButtonClick);
        StartCoroutine(DecreaseHeartCount());
        heartNumberUi.text = heartNumber.ToString();
        
        // Set the button as initially uninteractable
        button.interactable = false;
    }

    private void OnDestroy()
    {
        // Unsubscribe from the static collision event
        MovingObject.OnCollisionEventStatic -= OnCollisionEventTriggered;

        // Remove listener for button click event
        button.onClick.RemoveListener(OnButtonClick);
    }

    private void OnCollisionEventTriggered()
    {
        // Activate the button when the collision event is triggered
        // objectToActivate.SetActive(true);

        // Set the button as interactable when collision occurs
        button.interactable = true;
    }

    private void OnButtonClick()
    {
        heartNumber++;
        slider.value = CalculateSliderValue();
        heartNumberUi.text = heartNumber.ToString();

        // Deactivate the object when button is clicked
        // objectToActivate.SetActive(false);

        // Set the button as uninteractable after click
        button.interactable = false;
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

            // Adjust the value of the slider
            slider.value = CalculateSliderValue();
            heartNumberUi.text = heartNumber.ToString();
        }
    }
}
