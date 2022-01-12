using UnityEngine;

[System.Serializable] // 나중에 값을 인스펙터에 보여줄 수 있음

// 아이템을 정의하기 위해 새로만든 커스텀 클래스
public class Item 
{
    /* 변수 ( 소문자 대문자 ) */
    [SerializeField] int itemId;
    [SerializeField] string itemName;
    [SerializeField] string itemDescription;
    [SerializeField] Sprite itemSprite;
    [SerializeField] bool allowMultiple; // 중복 파밍 가능한지?
    [SerializeField] int amount; // 중복 파밍 개수

    /* parameter들을 serializeField 변수들에게 대입하는 컨스트럭터 */
    public Item(int itemId, string name, string desc, Sprite sprite, bool allowMultiple)
    {
        this.itemId = itemId;
        itemName = name;
        itemDescription = desc;
        itemSprite = sprite;
        this.allowMultiple = allowMultiple;
    }
    
    /* 프로퍼티 ( 대문자, 대문자 )*/
    public int ItemId { get { return itemId;  } }
    public string ItemName { get { return ItemName; } }
    public string ItemDescription { get { return itemDescription; } }
    public Sprite ItemSprite { get { return itemSprite; } }
    public bool AllowMultiple { get { return allowMultiple; } }

}

// itemId 는 새 아이템을 생성할 때 자동적으로 정해지기 때문에 itemId 을 위한 propertyField를 만들지 않을 것임 
