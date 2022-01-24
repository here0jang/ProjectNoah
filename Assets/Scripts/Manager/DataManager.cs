using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance { get; private set; }
    // �ٸ� ��ũ��Ʈ���� Inventory �� ���� ������ �� ������, ���� ������ �� ����
    public Inventory Inventory { get { return Inventory; } }

    [SerializeField] Inventory inventory;

    /* �̱��� ���� */
    // ������ �Ŵ��� �ڽŰ�, �� Ŭ������ ������ �ִ� ������Ʈ�� 
    private void Awake() // �ٸ� ��ũ��Ʈ���� ����Ǳ� ���� �ʱ�ȭ
    {
        if(Instance == null) // �ƹ��� Instance Ű���带 ������� �ʾ�����
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // ���࿡ ��1�� ��2 �Ѵ� ������ �Ŵ����� �����Ѵٸ�, ��2�� �̵��� �� ��1�� �����͸Ŵ����� ������Ŵ
            Destroy(gameObject); 

        }
    }
}