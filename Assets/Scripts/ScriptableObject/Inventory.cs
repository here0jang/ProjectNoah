using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Inventory", menuName = "Custom Data/Inventory Data")]

public class Inventory : ScriptableObject
{
    [SerializeField] ItemDatabase itemDatabase; // 아이템 데이터베이스의 오브젝트를 가져올 레퍼런스
    [SerializeField] List<Item> inventory = new List<Item>();

    public void AddItem(Item item)
    {
        inventory.Add(item);
    }

    public ItemDatabase ItemDatabase { get { return itemDatabase; } }


}
