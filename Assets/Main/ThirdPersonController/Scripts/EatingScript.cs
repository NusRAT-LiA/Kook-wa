using UnityEngine;
using TMPro;

public class EatingScript : MonoBehaviour
{
    public TMP_Text messageText;
    
    private bool isCooked = false;
    private bool isBeingCooked = false;
    private float cookingTime = 5.0f;
    private float elapsedTime = 0.0f;
    private HealthBar healthBar;

    void Start()
    {
        GameObject healthBarObject = GameObject.FindWithTag("HealthBar");
        if (healthBarObject != null)
        {
            healthBar = healthBarObject.GetComponent<HealthBar>();
        }
        else
        {
            Debug.LogWarning("HealthBar object not found with the tag 'HealthBar'. Make sure it's tagged correctly.");
        }
    }

    void Update()
    {
        if (isBeingCooked && !isCooked)
        {
            elapsedTime += Time.deltaTime;
            if (elapsedTime >= cookingTime)
            {
                isCooked = true;
                if (messageText != null)
                {
                    UpdateMessage("Object is cooked!");
                }
                Debug.Log("Object is cooked!");
            }
        }

        if (isCooked && Input.GetKeyDown(KeyCode.E))
        {
            if (healthBar != null)
            {
                healthBar.IncreaseHeartCount();
            }
            if (messageText != null)
            {
                UpdateMessage("Object is eaten!");
            }
            Debug.Log("Object is eaten!");
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Fire") && !isCooked)
        {
            isBeingCooked = true;
            if (messageText != null)
            {
                UpdateMessage("Object is being cooked!");
            }
            Debug.Log("Object is being cooked!");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Fire"))
        {
            isBeingCooked = false;
            if (messageText != null)
            {
                UpdateMessage("Object is no longer being cooked!");
            }
            Debug.Log("Object is no longer being cooked!");
        }
    }

    private void UpdateMessage(string newText)
    {
        if (messageText != null)
        {
            messageText.text = newText;
        }
    }
}
