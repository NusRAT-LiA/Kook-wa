using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireScript : MonoBehaviour
{
    public GameObject firePrefab;
    public ParticleSystem rainParticleSystem;


    void OnCollisionEnter(Collision collision)
    {
        // Check if the collision is with the log
        if (collision.gameObject.CompareTag("Log"))
        {
            // Get the position of the log
            Vector3 logPosition = collision.gameObject.transform.position;

            // Instantiate fire at the position of the log
            Instantiate(firePrefab, logPosition, Quaternion.identity);

            // Deactivate the wood stick GameObject
            gameObject.SetActive(false);

            // Disable grabbing for the log object
            ObjectGrabable grabable = collision.gameObject.GetComponent<ObjectGrabable>();
            if (grabable != null)
            {
                grabable.Activate();
            }
        }

        void Update()
    {
        // If it's raining, stop the fire particle system
        if (rainParticleSystem.isEmitting)
        {
            
                firePrefab.SetActive(false);
            
        }
        
    }
    }


}
