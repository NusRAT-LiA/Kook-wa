using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireScript : MonoBehaviour
{
    public GameObject firePrefab;
    public ParticleSystem rainParticleSystem;
    private GameObject currentFire;
    private GameObject collidedObject;

    public void TriggerFire(GameObject logObject)
    {
        // Check if the provided object is not null
        if (logObject != null)
        {
            Vector3 logPosition = logObject.transform.position;
            InstantiateFire(logPosition);

            collidedObject = logObject;

            ObjectGrabable grabable = logObject.GetComponent<ObjectGrabable>();
            if (grabable != null)
            {
                grabable.Activate();
            }

            Destroy(logObject, 25.0f);
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