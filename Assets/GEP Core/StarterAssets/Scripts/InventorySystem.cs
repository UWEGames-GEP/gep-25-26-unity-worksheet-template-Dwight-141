using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;

public class InventorySystem : MonoBehaviour
{
    public GameManager gameManager;
    public List<string> items = new List<string>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && gameManager.currentState == GameManager.GameState.PLAY)
        {
            AddItem("Common Item");
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && gameManager.currentState == GameManager.GameState.PLAY)
        {
            RemoveItem("Common Item");
        }
    }

    public void AddItem(string itemName)
    {
        items.Add(itemName);
    }

    public void RemoveItem(string itemName)
    {
        items.Remove(itemName);
    }
}
