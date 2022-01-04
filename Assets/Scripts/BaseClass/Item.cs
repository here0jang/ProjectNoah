using UnityEngine;

[System.Serializable]
public class Item 
{
    [SerializeField] int itemID;
    [SerializeField] string itemName;
    [SerializeField] string itemDescription;
    [SerializeField] Sprite itemSprite;
    [SerializeField] bool allowMultiple; // 중복 파밍 가능한지?
    [SerializeField] int amount; // 중복 파밍 개수
    
}
