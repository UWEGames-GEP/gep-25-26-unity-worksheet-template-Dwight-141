using TMPro;
using UnityEngine;

public class InventoryUIButton : MonoBehaviour
{
    public TMP_Text text;
    
    public void SetButton(itemScript item)
    {
        Debug.Log("Setting button to " + item.itemName);
        text.text = item.itemName;
    }
}
