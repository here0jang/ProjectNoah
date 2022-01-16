using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Inventory", menuName = "Custom Data/Inventory Data")]

public class Inventory : ScriptableObject
{
    [SerializeField] ItemDatabase itemDatabase; // 아이템 데이터베이스의 오브젝트를 가져올 레퍼런스
    [SerializeField] List<Item> inventory = new List<Item>();

    /* 인벤토리에 아이템을 추가하는 메서드 */
    public void AddItem(Item item)
    {
        inventory.Add(item); // 인벤토리 리스트에 item 추가
    }

    // ItemDatabase 스크립트의 itemsNames 에 List<string> 까지 가져오기 위해 필요 (objectReferenceValue는 object 로만 가져와짐 )
    public ItemDatabase ItemDatabase { get { return itemDatabase; } }
}
