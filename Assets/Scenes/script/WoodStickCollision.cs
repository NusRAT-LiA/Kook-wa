using UnityEngine;

public class WoodStickCollision : MonoBehaviour
{
    public GameObject firePrefab; // Reference to the fire particle system prefab

    void OnCollisionEnter(Collision collision)
    {
        // Check if the collision is with the rock
        if (collision.gameObject.CompareTag("Rock_01"))
        {
            // Instantiate fire at the collision point
            Instantiate(firePrefab, collision.contacts[0].point, Quaternion.identity);

            // Deactivate the wood stick GameObject
            gameObject.SetActive(false);
        }
    }
}
