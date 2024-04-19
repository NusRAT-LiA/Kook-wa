using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatingScript : MonoBehaviour
{
    private bool isCooked = false;
    private bool isBeingCooked = false;
    private float cookingTime = 5.0f; // Adjust as needed, represents how long the object needs to be cooked
    private float elapsedTime = 0.0f;

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
            // Code to eat the object
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

