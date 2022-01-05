using UnityEngine;

[System.Serializable]
public class Item 
{
    [SerializeField] int itemID;
    [SerializeField] string itemName;
    [SerializeField] string itemDescription;
    [SerializeField] Sprite itemSprite;
    [SerializeField] bool allowMultiple; // �ߺ� �Ĺ� ��������?
    [SerializeField] int amount; // �ߺ� �Ĺ� ����
    
}