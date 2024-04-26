using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCrafting : MonoBehaviour
{
    [SerializeField] private Transform playerCameraTransform;
    [SerializeField] private LayerMask interactLayerMask;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C) || Input.GetMouseButtonDown(0))
        {
            float interactDistance = 5.2f;
            // Debug.Log("Nola");
            if (Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out RaycastHit raycastHit, interactDistance, interactLayerMask))
            {
                // Debug.Log("Hola");
                if (raycastHit.transform.TryGetComponent(out CraftingAnvil craftingAnvil))
                {
                    Debug.Log("Hola");
                    if (Input.GetKeyDown(KeyCode.C))
                    {
                        craftingAnvil.NextRecipe();
                    }
                    if (Input.GetMouseButtonDown(0))
                    {
                        craftingAnvil.Craft();
                    }
                }
            }
        }
    }
}
