using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjData : MonoBehaviour
{
    //[SerializeField] int ID;
    //[SerializeField] string objectName;

    //[SerializeField] bool IsSmell;
    [SerializeField] string smellText;

    //[SerializeField] bool IsObserve;
    [SerializeField] Transform observeView;

    //[SerializeField] bool IsBark;
    /* ������Ʈ�� ¢�� �ϸ� ����� ���� */

    // 

    public string SmellText { get { return smellText; } }

    public Transform ObserveView { get { return observeView; } }
}