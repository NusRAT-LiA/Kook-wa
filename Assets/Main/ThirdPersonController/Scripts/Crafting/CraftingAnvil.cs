using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftingAnvil : MonoBehaviour
{
    [SerializeField] private Image recipeImage;
    [SerializeField] private List<CraftingRecipeSO> craftingRecipeSOList;
    [SerializeField] private BoxCollider placeItemsAreaBoxCollider;
    [SerializeField] private Transform itemSpawnPoint;
    [SerializeField] private Transform vfxSpawnItem;

    private CraftingRecipeSO craftingRecipeSO;

    private void Awake()
    {
        NextRecipe();
    }

    public void NextRecipe()
    {
        if (craftingRecipeSO == null)
        {
            craftingRecipeSO = craftingRecipeSOList[0];
        }
        else
        {
            int index = craftingRecipeSOList.IndexOf(craftingRecipeSO);
            index = (index + 1) % craftingRecipeSOList.Count;
            craftingRecipeSO = craftingRecipeSOList[index];
        }

        recipeImage.sprite = craftingRecipeSO.sprite;
    }

    public void Craft()
    {

        Collider[] colliderArray = Physics.OverlapBox(transform.position + placeItemsAreaBoxCollider.center, placeItemsAreaBoxCollider.size, placeItemsAreaBoxCollider.transform.rotation);

        List<ItemSO> inputItemList = new List<ItemSO>(craftingRecipeSO.inputItemSOList);
        List<GameObject> consumeItemGameObjectList = new List<GameObject>();

        foreach (Collider collider in colliderArray)
        {
            if (collider.TryGetComponent(out ItemSOHolder itemSOHolder))
            {
                if (inputItemList.Contains(itemSOHolder.itemSO))
                {
                    inputItemList.Remove(itemSOHolder.itemSO);
                    consumeItemGameObjectList.Add(collider.gameObject);
                }
            }
        }

        if (inputItemList.Count == 0)
        {
            Debug.Log("Yes");
            Transform spawnedItemTransform = Instantiate(craftingRecipeSO.outputItemSO.prefab, itemSpawnPoint.position, itemSpawnPoint.rotation);
            Instantiate(vfxSpawnItem, itemSpawnPoint.position, itemSpawnPoint.rotation);

            foreach(GameObject consumeGameObject in consumeItemGameObjectList){
                Destroy(consumeGameObject);
            }
        }
        else
        {
            Debug.Log("No");
        }
    }

}