using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPipe : MonoBehaviour, IInventoryItem
{
    public string Name
    {
        get
        {
            return "NPipe";
        }
    }

    public Sprite _Image = null;

    public Sprite Image
    {
        get
        {
            return _Image;
        }

    }

    public void OnPickUp()
    {
        // Add logic what happens when axe is picked up by player
        gameObject.SetActive(false);
    }
}
