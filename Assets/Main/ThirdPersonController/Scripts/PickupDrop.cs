using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupDrop : MonoBehaviour
{
    [SerializeField] private Transform playerCameraTransform;
    [SerializeField] private LayerMask pickUpLayerMask;
    [SerializeField] private Transform ObjectGrabPointTransform;

    private ObjectGrabable objectGrabable;

    // Reference to the FireScript
    public FireScript fireScript;

    // Update is called once per frame
    private void Update()
{
    // Check for picking up or dropping the object
    if (Input.GetKeyDown(KeyCode.F))
    {
        if (objectGrabable == null)
        {
            float pickupDistance = 6f;
            if (Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out RaycastHit raycastHit, pickupDistance, pickUpLayerMask))
            {
                if (raycastHit.transform.TryGetComponent(out objectGrabable))
                {
                    objectGrabable.Grab(ObjectGrabPointTransform);
                }
            }
        }
        else
        {
            objectGrabable.Drop();
            objectGrabable = null;
        }
    }

    // Check for triggering fire without collision if an object is grabbed
    if (Input.GetKeyDown(KeyCode.T) && objectGrabable != null && objectGrabable.CompareTag("Log"))
        {
            // Call the method in FireScript and pass the grabbed object
            fireScript.TriggerFire(objectGrabable.gameObject);
        }
}
}

// public class FireScript : MonoBehaviour
// {
//     public GameObject firePrefab;
//     public ParticleSystem rainParticleSystem;
//     private GameObject currentFire;
//     private GameObject collidedObject;

//     // Simulate collision with log
//     public void TriggerFire(GameObject logObject)
//     {
//         // Check if the provided object is not null
//         if (logObject != null)
//         {
//             Vector3 logPosition = logObject.transform.position;
//             InstantiateFire(logPosition);

//             collidedObject = logObject;

//             ObjectGrabable grabable = collidedObject.GetComponent<ObjectGrabable>();
//             if (grabable != null)
//             {
//                 grabable.Activate();
//             }

//             Destroy(logObject, 25.0f);
//             // OnCollisionEnter(new Collision { gameObject = logObject, transform = { position = logPosition } });
//         }
//     }

//     // private void OnCollisionEnter(Collision collision)
//     // {
//     //     // Check if the collision is with the log
//     //     if (collision.gameObject.CompareTag("Log"))
//     //     {
//     //         Vector3 logPosition = collision.gameObject.transform.position;

//     //         InstantiateFire(logPosition);

//     //         collidedObject = collision.gameObject;

//     //         ObjectGrabable grabable = collidedObject.GetComponent<ObjectGrabable>();
//     //         if (grabable != null)
//     //         {
//     //             grabable.Activate();
//     //         }

//     //         Destroy(collidedObject, 25.0f); // Destroy the log object

//     //         // SetFireInactive();
//     //     }
//     // }

//     void Update()
//     {
//         if (rainParticleSystem != null && rainParticleSystem.isPlaying)
//         {
//             // If fire exists, extinguish it
//             if (currentFire != null)
//             {
//                 ExtinguishFire();
//                 if (collidedObject != null)
//                 {
//                     Destroy(collidedObject, 0.1f);
//                 }
//             }
//         }
//     }

//     private void InstantiateFire(Vector3 position)
//     {
//         // Instantiate fire prefab at the collision position
//         currentFire = Instantiate(firePrefab, position, Quaternion.identity);
//     }

//     private void ExtinguishFire()
//     {
//         Debug.Log(currentFire);
//         Destroy(currentFire);
//         currentFire = null;
//     }

//     // private void SetFireInactive()
//     // {
//     //     Collider collider = GetComponent<Collider>();
//     //     if (collider != null)
//     //     {
//     //         collider.enabled = false;
//     //     }

//     //     Renderer renderer = GetComponent<Renderer>();
//     //     if (renderer != null)
//     //     {
//     //         renderer.enabled = false;
//     //     }
//     // }
// }