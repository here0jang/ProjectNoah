using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BiteDestroyButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler
{
    public static BiteDestroyButton bitedestroybutton { get; private set; }


    void Awake()
    {
        bitedestroybutton = this;
    }
    public Animator playeranimation;
    [SerializeField] float requiredHoldTime = 1f;
    [SerializeField] float requiredChangeTime = 0.5f;
    float pointerDownTimer = 0;

    public Button BiteButton;
    public Sprite BiteButtonImage;
    public Sprite BiteButtonMouseOver;
    public Sprite BiteButtonClicked; // PlayerScripts - MovePlayer 에서 버튼 이미지 BiteButtonImage 로 바꿈
    public Sprite DestroyButtonMouseOver;

    bool pointerDown = false;

    public bool ISBITE = false;

    public GameObject noahbiteObject;


    public GameObject myMouth;

    void Update()
    {
        if (pointerDown)
        {
            //playerBite();
            pointerDownTimer += Time.deltaTime;
            if (pointerDownTimer >= requiredChangeTime)
            {
                ChangeBiteToDestroyButton();
                if (pointerDownTimer >= requiredHoldTime)
                {
                    playerDestroy();
                    Reset();
                }
            }
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        BiteButton.GetComponent<Image>().sprite = BiteButtonMouseOver;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        BiteButton.GetComponent<Image>().sprite = BiteButtonImage;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        BiteButton.GetComponent<Image>().sprite = BiteButtonClicked;
        longButton.longbutton.TurnOffInteractionButton();
        //playerBite();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        pointerDown = true;
        ISBITE = true;
        noahbiteObject = PlayerScripts.playerscripts.PlayerNoahBiteObject;

        Invoke("ChangeBiteTrue", 0.5f);

        Invoke("PlayerPickUp", 0.7f);
        Invoke("ChangeBiteFalse", 1);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Reset();
    }

    private void Reset()
    {
        pointerDown = false;
        pointerDownTimer = 0;
    }

    void playerBite()
    {
        ISBITE = true;
        noahbiteObject = PlayerScripts.playerscripts.PlayerNoahBiteObject;

        longButton.longbutton.TurnOffInteractionButton();

        Invoke("ChangeBiteTrue", 0.5f);

        //noahbiteObject = PlayerScripts.playerscripts.PlayerNoahBiteObject;
        //biteObject = PlayerScripts.playerscripts.PlayerbiteObject;

        Invoke("PlayerPickUp", 0.7f);
        //Invoke("TurnOffEnvirObject", 1.1f);


        Invoke("ChangeBiteFalse", 2);
    }

    void ChangeBiteTrue()
    {
        playeranimation.SetBool("IsBiting", true);
    }

    void ChangeBiteFalse()
    {
        playeranimation.SetBool("IsBiting", false);
    }

    //void BiteObject()
    //{
    //    //noahbiteObject.transform.gameObject.SetActive(true);
    //    //PickUpObject.pickupobject.PlayerPickUp(ObjectIwantToPickUp);
    //}

    //void TurnOffEnvirObject()
    //{
    //    //biteObject.transform.gameObject.SetActive(false);
    //}
    void PlayerPickUp()
    {
        noahbiteObject.GetComponent<Rigidbody>().isKinematic = true;   //makes the rigidbody not be acted upon by forces
        noahbiteObject.GetComponent<Rigidbody>().useGravity = false;
        noahbiteObject.transform.position = myMouth.transform.position; // sets the position of the object to your hand position
        noahbiteObject.transform.parent = myMouth.transform; //makes the object become a child of the parent so that it moves with the hands
    }

    void ChangeBiteToDestroyButton()
    {
        BiteButton.GetComponent<Image>().sprite = DestroyButtonMouseOver;
    }

    void playerDestroy()
    {
        longButton.longbutton.TurnOffInteractionButton();




        Invoke("ChangeDestroyTrue", 2f);
        Invoke("ChangeDestroyFalse", 4f);
    }

    void ChangeDestroyTrue()
    {
        playeranimation.SetBool("IsDestroying", true);
    }

    void ChangeDestroyFalse()
    {
        playeranimation.SetBool("IsDestroying", false);
    }

}
