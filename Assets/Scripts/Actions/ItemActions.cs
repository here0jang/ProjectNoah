using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemActions : Actions
{
    [SerializeField] ItemDatabase itemDatabase;
    [SerializeField] bool giveItem; // This will decide whether we are giveing or receiving the item
    [SerializeField] Actions[] yesAction, noAction;

    private Item currentItem; // ���� ���� �������� �����, �������� �����Ϳ� ���ؼ� �÷��̾ �� �������� �ٰ����� �ƴ����� ���� 
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