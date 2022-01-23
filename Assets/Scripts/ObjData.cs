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
    /* 오브젝트에 짖기 하면 생기는 반응 */

    // 

    public string SmellText { get { return smellText; } }

    public Transform ObserveView { get { return observeView; } }
}
