using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class UIBehaviour : MonoBehaviour
{
    public InventorySystem inventorySystem;
    public List<GameObject> inventoryUIButtons = new List<GameObject>();

    private void OnEnable()
    {
        RefreshInventory();
    }

    public void OnInventoryUIButton(int i)
    {
        inventorySystem.RemoveItem(i);
        RefreshInventory();
    }

    void RefreshInventory()
    {
        Debug.Log("Refresh Inv UI");
        foreach (GameObject uiButton in inventoryUIButtons)
        {
            uiButton.SetActive(false);
        }

        for (int i = 0; i < inventorySystem.items.Count; i++)
        {
            if (i < inventoryUIButtons.Count)
            {
                InventoryUIButton uiButton = inventoryUIButtons[i].GetComponent<InventoryUIButton>();
                itemScript item = inventorySystem.items[i];

                uiButton.gameObject.SetActive(true);
                uiButton.SetButton(item);
            }
        }
    }
}
