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
// �κ��丮�� �̺�Ʈ�� �߻���Ų��.Args : argument
public class InventoryEventArgs : EventArgs
{
    public InventoryEventArgs(IInventoryItem item)
    {
        Item = item; // ���߿� NItem ���� �ٲ۴�
    }

    public IInventoryItem Item;
}