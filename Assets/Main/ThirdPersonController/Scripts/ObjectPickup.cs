using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPickup : MonoBehaviour
{
    public GameObject pickup;
    public GameObject playerRightHand;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PickupObject(){
        pickup.transform.SetParent(playerRightHand.transform);
    }

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Log")){
            pickup = other.gameObject;
        }
    }
}