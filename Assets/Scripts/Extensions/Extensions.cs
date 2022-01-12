using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems; // 마우스가 UI 위에 있는지 체크하기 위해 필요
/* UI 를 클릭한 것이 맞는지 체크하는 스크립트 */
// 대화창 UI 를 클릭하면 대화는 넘어가지만 플레이어는 대화창쪽으로 움직이지 않게 하기


// 정적 클래스
// 정적 변수와 메서드만 가질 수 있음
// 클래스로부터 객체를 생성하지 않고 변수나 함수를 호출할 수 있음

public static class Extensions
{
    /* 마우스가 현재 UI 위에 있으면 참을 반환하는 메서드 */
    public static bool IsMouseOverUI()
    { 
        return EventSystem.current.IsPointerOverGameObject();
    }

    /* 아이템을 복사하는 메서드 */
    public static Item CopyItem(Item item)
    {// get set 차이
        Item newItem = new Item(item.ItemId, item.ItemName, item.ItemDescription, item.ItemSprite, item.AllowMultiple);

        return newItem;
    }

}
