using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPickup : MonoBehaviour
{
    public GameObject pickup;
    public GameObject playerLeftHand;
    public GameObject dropOffPoint;
    private Vector3 originalScale;

    private bool isSomethingInHand = false;
    // Start is called before the first frame update
    void Start()
    {
        // originalScale = pickup.transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        originalScale = pickup.transform.localScale;
    }

    public void PickupObject()
    {
        if (isSomethingInHand == true)
        {
            pickup.transform.parent = null;
            pickup.transform.localPosition = dropOffPoint.transform.position;
            isSomethingInHand = false;
        }
        else
        {
            if (pickup != null)
            {
                pickup.transform.SetParent(playerLeftHand.transform);
                pickup.transform.localPosition = new Vector3(0f, 0f, 0f);
                pickup.transform.localScale = originalScale;
                isSomethingInHand = true;
            }
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pickable"))
        {
            pickup = other.gameObject;
            Debug.Log("It is pickable: " + other.gameObject.name);
        }
    }
}