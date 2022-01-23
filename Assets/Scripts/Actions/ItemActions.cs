using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemActions : Actions
{
    [SerializeField] ItemDatabase itemDatabase;
    [SerializeField] bool giveItem; // This will decide whether we are giveing or receiving the item
    [SerializeField] Actions[] yesAction, noAction;

    private Item currentItem; // 현재 집은 아이템이 저장됨, 아이템의 데이터와 비교해서 플레이어가 이 아이템을 줄것인지 아닌지를 결정 
    public override void Act()
    {
        // check if giveItem is true, than give the item
            // check if we own the item
                // check if the item has the allowMultiple option or not
                    // check how many item needed, give and subtract our item
                // else give and remove the item
        // else receive the item
        
    }
}
