using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatingPotion : MonoBehaviour
{
    private bool isNearPotion = false;
    private GameObject otherGameObject; // Reference to the game object of the other collider
    public PotionBar potionBar; // Reference to the PotionBar script

    void Start()
    {
        // Find the object with the PotionBar script attached
        // GameObject potionBarObject = GameObject.FindWithTag("PotionBar");

        // // Get the PotionBar component from the object
        // potionBar = potionBarObject.GetComponent<PotionBar>();
        // Debug.Log(potionBar);
    }

    void Update()
    {
        if (isNearPotion && Input.GetKeyDown(KeyCode.E))
        {
            HandleEating();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Potion"))
        {
            Debug.Log("Jelo");
            isNearPotion = true;
            otherGameObject = other.gameObject; // Store reference to the game object of the other collider
        }
    }

    void HandleEating()
    {
        Debug.Log("Player has eaten the potion!");

        // Check if otherGameObject is not null before attempting to destroy it
        if (otherGameObject != null)
        {
            Destroy(otherGameObject);
            potionBar.FillSpellBar(); // Call the FillSpellBar method from the PotionBar script
        }
    }
}
