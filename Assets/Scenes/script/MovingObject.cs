using UnityEngine;
using UnityEngine.Events;
using System;
using System.Collections.Generic;

public class MovingObject : MonoBehaviour
{
    public float speed = 5f;
    public static event Action OnCollisionEventStatic; // Static event to be raised on collision

    private void Update()
    {
        // Move the object along the x-axis
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Trigger the static collision event when collision occurs
        OnCollisionEventStatic?.Invoke();
    }
}
