using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ObjData : MonoBehaviour
{
    //[SerializeField] int ID;
    //[SerializeField] string objectName;

    //[SerializeField] bool IsSmell;
    [SerializeField] string smellText;

    [SerializeField] Button centerButton; // 가운데 추가행동 : 관찰, 오르기... 없으면 centerDisable 넣으면 됨

    //[SerializeField] bool isObserve;
    [SerializeField] Transform observeView;

    //[SerializeField] bool IsBark;
    /* 오브젝트에 짖기 하면 생기는 반응 */

    //[SerializeField] bool IsBite;
    [SerializeField] GameObject playerBiteObject;

    [SerializeField] GameObject playerPushObject;

    [SerializeField] Vector3 interactionButtonPosition;



    public string SmellText { get { return smellText; } }

    public Button CenterButton { get { return centerButton; } }

    public Transform ObserveView { get { return observeView; } }

    public GameObject PlayerBiteObject { get { return playerBiteObject; } }

    public GameObject PlayerPushObject { get { return playerPushObject; } }

    public Vector3 InteractionButtonPosition { get { return interactionButtonPosition; } }
}
