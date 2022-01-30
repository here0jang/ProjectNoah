using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public NInventory NInventory;
    // Start is called before the first frame update
    void Start()
    {
        NInventory.ItemAdded += NInventoryScript_ItemAdded;
    }

    private void NInventoryScript_ItemAdded(object sender, InventoryEventArgs e)
    {
        Transform ninventoryPanel = transform.Find("InventoryPanel");
        foreach (Transform slot in ninventoryPanel) // 인벤토리를 돌면서 빈칸을 찾아 아이템 할당
        {
            // Border... Image
            Image image = slot.GetChild(0).GetChild(0).GetComponent<Image>();

            // we found the empty slot
            if(!image.enabled)
            {
                image.enabled = true;
                image.sprite = e.Item.Image;

                // TODO : Store a reference to the item
                break;
            }
        }
    }
}
