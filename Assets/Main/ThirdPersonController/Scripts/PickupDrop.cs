using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupDrop : MonoBehaviour
{
    [SerializeField] private Transform playerCameraTransform;
    [SerializeField] private LayerMask pickUpLayerMask;
    [SerializeField] private Transform ObjectGrabPointTransform;

    private ObjectGrabable objectGrabable;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (objectGrabable == null)
            {
                float pickupDistance = 5.1f;
                if (Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out RaycastHit raycastHit, pickupDistance, pickUpLayerMask))
                {
                    if (raycastHit.transform.TryGetComponent(out objectGrabable))
                    {
                        objectGrabable.Grab(ObjectGrabPointTransform);
                        // Debug.Log(raycastHit.transform);
                    }
                }

            }
            else{
                objectGrabable.Drop();
                objectGrabable = null;
            }

        }
    }
}
