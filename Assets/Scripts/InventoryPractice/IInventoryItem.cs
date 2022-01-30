using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInventoryItem
{
    string Name { get; }
    Sprite Image { get; }

    void OnPickUp();
}
// 인벤토리는 이벤트를 발생시킨다.Args : argument
public class InventoryEventArgs : EventArgs
{
    public InventoryEventArgs(IInventoryItem item)
    {
        Item = item; // 나중에 NItem 으로 바꾼다
    }

    public IInventoryItem Item;
}