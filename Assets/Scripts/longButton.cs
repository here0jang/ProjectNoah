using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class longButton : MonoBehaviour
{
    public static longButton longbutton { get; private set; }

    //[SerializeField] float requiredHoldTime = 1f;
    //[SerializeField] float requiredChangeTime = 0.5f;
    //float pointerDownTimer = 0;

    //public Sprite BiteButtonImage;
    //public Sprite BiteButtonMouseOver;
    //public Sprite BiteButtonClicked; // PlayerScripts - MovePlayer 에서 버튼 이미지 BiteButtonImage 로 바꿈
    //public Sprite DestroyButtonMouseOver;

    //bool pointerDown = false;

    public Animator PlayerAnim;
    public Button barkButton, pushButton, sniffButton, biteButton, noCenterButton;

    private bool isobjectobserve;
    public Button observeButton; 

    [SerializeField] GameObject Noah;
    public GameObject noahpushObject;
    public bool ispush = false;
    public bool IsBark = false;

    void Awake()
    {
        longbutton = this;
        barkButton.onClick.AddListener(playerBark);
        sniffButton.onClick.AddListener(playerSniff);
        observeButton.onClick.AddListener(playerObserve);

        pushButton.onClick.AddListener(playerPush);
    }

    //void Update()
    //{
    //    if (pointerDown)
    //    {
    //        playerBite();
    //        pointerDownTimer += Time.deltaTime;
    //        if (pointerDownTimer >= requiredChangeTime)
    //        {
    //            ChangeBiteToDestroyButton();
    //            if (pointerDownTimer >= requiredHoldTime)
    //            {
    //                playerDestroy();
    //                Reset();
    //            }
    //        }
    //    }
    //}

    //public void OnPointerEnter(PointerEventData eventData)
    //{
    //    biteButton.GetComponent<Image>().sprite = BiteButtonMouseOver;
    //}

    //public void OnPointerExit(PointerEventData eventData)
    //{
    //    biteButton.GetComponent<Image>().sprite = BiteButtonImage;
    //}

    //public void OnPointerClick(PointerEventData eventData)
    //{
    //    biteButton.GetComponent<Image>().sprite = BiteButtonClicked;
    //    playerBite();
    //}

    //public void OnPointerDown(PointerEventData eventData)
    //{
    //    pointerDown = true;
    //    Invoke("ChangeBiteTrue", 0.5f);
    //    Invoke("ChangeBiteFalse", 1);
    //}

    //public void OnPointerUp(PointerEventData eventData)
    //{
    //    Reset();
    //}

    //private void Reset()
    //{
    //    pointerDown = false;
    //    pointerDownTimer = 0;
    //}

    public void TurnOffInteractionButton()
    {
        barkButton.transform.gameObject.SetActive(false);
        pushButton.transform.gameObject.SetActive(false);
        noCenterButton.transform.gameObject.SetActive(false);
        observeButton.transform.gameObject.SetActive(false);
        sniffButton.transform.gameObject.SetActive(false);
        biteButton.transform.gameObject.SetActive(false);
    }
    //&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&

    //void playerBite()
    //{
    //    isbite = true;
    //    noahbiteObject = PlayerScripts.playerscripts.PlayerNoahBiteObject;

    //    TurnOffInteractionButton();
    //    Invoke("ChangeBiteTrue", 0.5f);
        
    //    //noahbiteObject = PlayerScripts.playerscripts.PlayerNoahBiteObject;
    //    //biteObject = PlayerScripts.playerscripts.PlayerbiteObject;
    //    Invoke("PlayerPickUp", 0.7f);
    //    //Invoke("TurnOffEnvirObject", 1.1f);


    //    Invoke("ChangeBiteFalse", 2);
    //}

    //void ChangeBiteTrue()
    //{
    //    PlayerAnim.SetBool("IsBiting", true);
    //}

    //void ChangeBiteFalse()
    //{
    //    PlayerAnim.SetBool("IsBiting", false);
    //}

    //void BiteObject()
    //{
    //    //noahbiteObject.transform.gameObject.SetActive(true);
    //    //PickUpObject.pickupobject.PlayerPickUp(ObjectIwantToPickUp);
    //}

    ////void TurnOffEnvirObject()
    ////{
    ////    //biteObject.transform.gameObject.SetActive(false);
    ////}
    //void PlayerPickUp()
    //{
    //    noahbiteObject.GetComponent<Rigidbody>().isKinematic = true;   //makes the rigidbody not be acted upon by forces
    //    noahbiteObject.GetComponent<Rigidbody>().useGravity = false;
    //    noahbiteObject.transform.position = myMouth.transform.position; // sets the position of the object to your hand position
    //    noahbiteObject.transform.parent = myMouth.transform; //makes the object become a child of the parent so that it moves with the hands
    //}


    //void PlayerPickDown()
    //{
    //    ObjectIwantToPickUp.GetComponent<Rigidbody>().isKinematic = false; // make the rigidbody work again
    //    ObjectIwantToPickUp.GetComponent<Rigidbody>().useGravity = true;
    //    ObjectIwantToPickUp.transform.parent = null; // make the object no be a child of the hands
    //}



    //&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&

    void playerBark()
    {
        PlayerManager.playermanager.isBark = true;
        TurnOffInteractionButton();
        Invoke("ChangeBarkTrue", 0.5f);
        Invoke("ChangeBarkFalse", 2);
    }

    void ChangeBarkTrue()
    {
        PlayerAnim.SetBool("IsBarking", true);
    }

    void ChangeBarkFalse()
    {
        PlayerAnim.SetBool("IsBarking", false);
    }
    /* 오브젝트에 짖었을 때 그에 맞는 반응 필요 */



    //&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&

    void playerSniff()
    {
        TurnOffInteractionButton();
        Invoke("ChangeSniffTrue", 0.5f);
        Invoke("ChangeSniffFalse", 2);
        Invoke("TurnOnTheSmellPanel", 2);
    }

    void ChangeSniffTrue()
    {
        PlayerAnim.SetBool("IsSniffing", true);
    }

    void ChangeSniffFalse()
    {
        PlayerAnim.SetBool("IsSniffing", false);
    }

    void TurnOnTheSmellPanel()
    {
        DialogSystem.Instance.Smell();
    }

    //&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&

    void playerObserve()
    {
        TurnOffInteractionButton();
        Invoke("ChangeObserveTrue", 0.5f);
        Invoke("ChangeObserveFalse", 2);
        Invoke("ChangeCameraView", 2);
    }

    void ChangeObserveTrue()
    {
        PlayerAnim.SetBool("IsObserving", true);
    }

    void ChangeObserveFalse()
    {
        PlayerAnim.SetBool("IsObserving", false);
    }

    void ChangeCameraView()
    {
        cam.newCam.ObserveButtonClick();
        Noah.transform.gameObject.SetActive(false);
        //isobjectobserve = PlayerScripts.playerscripts.ObjectIsObserve;
    }

    //&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&

    void playerPush()
    {
        noahpushObject = PlayerScripts.playerscripts.PlayerNoahPushObject;
        ispush = true;
        PlayerManager.playermanager.isPush = true;
        TurnOffInteractionButton();
        Invoke("ChangePushTrue", 0.5f);
        noahpushObject.transform.parent = Noah.transform;
    }

    void ChangePushTrue()
    {
        PlayerAnim.SetBool("IsPushing", true);
    }

    //void ChangePushFalse()
    //{
    //    PlayerAnim.SetBool("IsPushing", false);
    //}
     
    //&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&


}
