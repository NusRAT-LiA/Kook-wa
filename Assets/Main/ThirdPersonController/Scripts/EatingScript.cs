using UnityEngine;

public class EatingScript : MonoBehaviour
{
    private bool isCooked = false;
    private bool isBeingCooked = false;
    private float cookingTime = 5.0f; // Adjust as needed, represents how long the object needs to be cooked
    private float elapsedTime = 0.0f;
    private HealthBar healthBar; // Reference to the HealthBar script

    void Start()
    {
        // Find the GameObject with the "HealthBar" tag and get the HealthBar component
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

    // Update is called once per frame
    void Update()
    {
        if (isBeingCooked && !isCooked)
        {
            elapsedTime += Time.deltaTime;
            if (elapsedTime >= cookingTime)
            {
                isCooked = true;
                Debug.Log("Object is cooked!");
            }
        }

        if (isCooked && Input.GetKeyDown(KeyCode.E))
        {
            if (healthBar != null) // Check if the reference is not null
            {
                healthBar.IncreaseHeartCount(); // Call IncreaseHeartCount from HealthBar script
            }
            Debug.Log("Object is eaten!");
            Destroy(gameObject); // Destroy the object after eating
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Fire") && !isCooked)
        {
            isBeingCooked = true;
            Debug.Log("Object is being cooked!");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Fire"))
        {
            isBeingCooked = false;
            Debug.Log("Object is no longer being cooked!");
        }
    }
}
