using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Inventory", menuName = "Custom Data/Inventory Data")]

public class Inventory : ScriptableObject
{
    [SerializeField] ItemDatabase itemDatabase; // ������ �����ͺ��̽��� ������Ʈ�� ������ ���۷���
    [SerializeField] List<Item> inventory = new List<Item>();

    /* �κ��丮�� �������� �߰��ϴ� �޼��� */
    public void AddItem(Item item)
    {
        inventory.Add(item); // �κ��丮 ����Ʈ�� item �߰�
    }

    // ItemDatabase ��ũ��Ʈ�� itemsNames �� List<string> ���� �������� ���� �ʿ� (objectReferenceValue�� object �θ� �������� )
    public ItemDatabase ItemDatabase { get { return itemDatabase; } }
}