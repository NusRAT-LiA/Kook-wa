using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireScript : MonoBehaviour
{
    public GameObject firePrefab;
    public ParticleSystem rainParticleSystem;
    private GameObject currentFire;
    private GameObject collidedObject;

    void OnCollisionEnter(Collision collision)
    {
        // Check if the collision is with the log
        if (collision.gameObject.CompareTag("Log"))
        {
            Vector3 logPosition = collision.gameObject.transform.position;

            InstantiateFire(logPosition);
            Debug.Log(currentFire);

            collidedObject = collision.gameObject;

            Destroy(collidedObject, 25.0f); // Destroy the log object

            // Disable grabbing for the log object
            ObjectGrabable grabable = collidedObject.GetComponent<ObjectGrabable>();
            if (grabable != null)
            {
                grabable.Activate();
            }

            SetFireInactive();
        }
    }

    void Update()
    {
        if (rainParticleSystem != null && rainParticleSystem.isPlaying)
        {
            // If fire exists, extinguish it
            if (currentFire != null)
            {
                ExtinguishFire();
                if (collidedObject != null)
                {
                    Destroy(collidedObject, 0.1f);
                }
            }
        }
    }

    private void InstantiateFire(Vector3 position)
    {
        // Instantiate fire prefab at the collision position
        currentFire = Instantiate(firePrefab, position, Quaternion.identity);
    }

    private void ExtinguishFire()
    {
        Debug.Log(currentFire);
        Destroy(currentFire);
        currentFire = null;
    }

    private void SetFireInactive()
    {
        Collider collider = GetComponent<Collider>();
        if (collider != null)
        {
            collider.enabled = false;
        }

        Renderer renderer = GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.enabled = false;
        }
    }
}
