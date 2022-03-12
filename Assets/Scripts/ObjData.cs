using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ObjData : MonoBehaviour
{
    //public int id;

    //[SerializeField] string objectName;

    [SerializeField] string smellText;

    [SerializeField] Button centerButton; // 가운데 추가행동 : 관찰, 오르기... 없으면 centerDisable 넣으면 됨

    [SerializeField] Button pushOrPressButton; // 물건 옮기기 : push, 버튼 누르기 : press 

    [SerializeField] Transform observeView;

    [SerializeField] Transform observePlusView;



    public string SmellText { get { return smellText; } }
    public Button PushOrPressButton { get { return pushOrPressButton; } }
    public Button CenterButton { get { return centerButton; } }
    public Transform ObserveView { get { return observeView; } }
    public Transform ObservePlusView { get { return observePlusView; } }

    public bool IsBark = false;
    public bool IsPushOrPress = false;
    public bool IsSniff = false;
    public bool IsBite = false;

    public bool IsUpDown = false;
    public bool IsInsert = false;
    public bool IsObserve = false;
    public bool IsObservePlus = false;
    public bool IsExtraDescriptionActive = false;

    public GameObject exterDescription;
    
}
