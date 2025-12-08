using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;
using static GameManager;

public class InventorySystem : MonoBehaviour
{
    public GameManager gameManager;
    public Transform worldItemsTransform;
    public List<itemScript> items = new List<itemScript>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();
        Transform worldItemsTransform = GameObject.Find("WorldItems").transform;
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (Input.GetKeyDown(KeyCode.Alpha1) && gameManager.currentState == GameManager.GameState.PLAY)
        {
            AddItem("Common Item");
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && gameManager.currentState == GameManager.GameState.PLAY)
        {
            RemoveItem("Common Item");
        }*/
    }

    public void AddItem(itemScript item)
    {
        items.Add(item);
    }

    /*public void RemoveItem(itemScript item)
    {
        items.Remove(item);
    }*/

    public void RemoveItem()
    {
        if ((gameManager.currentState == GameState.PLAY) && (items.Count > 0))
        {
            itemScript item = items[0];

            Vector3 currentPosition = transform.position;
            Vector3 forward = transform.forward;

            Vector3 newPosition = currentPosition + forward;
            newPosition += new Vector3(0, 1, 0);

            Quaternion currentRotation = transform.rotation;
            Quaternion newRotation = currentRotation * Quaternion.Euler(0, 0, 180);

            GameObject newItem = Instantiate(item.gameObject, newPosition, newRotation, worldItemsTransform);
            newItem.SetActive(true);

            items.Remove(item);
            Destroy(item.gameObject);
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        itemScript collisionItem = hit.gameObject.GetComponent<itemScript>();

        if (collisionItem != null)
        {
            items.Add(collisionItem);
            collisionItem.gameObject.SetActive(false);
        }
    }
}
