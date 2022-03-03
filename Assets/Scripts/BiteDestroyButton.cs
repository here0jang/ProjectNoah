using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BiteDestroyButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
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
    // PlayerScripts - MovePlayer 에서 버튼 이미지 BiteButtonImage 로 바꿈
    public Sprite BiteButtonImage, BiteButtonMouseOver, BiteButtonClicked, DestroyButtonMouseOver;

    bool pointerDown = false;

    public bool ISBITE = false;

    public GameObject noahbiteObject;
    public GameObject myMouth;

    void Update()
    {
        if (pointerDown)
        {
            pointerDownTimer += Time.deltaTime;
            if (pointerDownTimer >= requiredChangeTime)
            {
                ChangeBiteToDestroyButton();

                Invoke("ChangeDestroyTrue", 1f);
                longButton.longbutton.TurnOffInteractionButton();
                Invoke("ChangeDestroyFalse", 3f);

                Reset();
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

    public void OnPointerUp(PointerEventData eventData)
    {
        longButton.longbutton.TurnOffInteractionButton();
        Reset();
    }

    private void Reset()
    {
        pointerDown = false;
        pointerDownTimer = 0;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        BiteButton.GetComponent<Image>().sprite = BiteButtonClicked;
        pointerDown = true;
        noahbiteObject = PlayerScripts.playerscripts.PlayerNoahBiteObject;

        Invoke("ChangeBiteTrue", 0.5f);
        Invoke("PlayerPickUp", 0.7f);
        Invoke("ChangeBiteFalse", 1);
    }

    void ChangeBiteTrue()
    {
        playeranimation.SetBool("IsBiting", true);
    }

    void ChangeBiteFalse()
    {
        playeranimation.SetBool("IsBiting", false);
    }

    void PlayerPickUp()
    {
        ISBITE = true;
        noahbiteObject.GetComponent<Rigidbody>().isKinematic = true;   //makes the rigidbody not be acted upon by forces
        noahbiteObject.GetComponent<Rigidbody>().useGravity = false;
        noahbiteObject.transform.parent = myMouth.transform; //makes the object become a child of the parent so that it moves with the mouth
        noahbiteObject.transform.localPosition = new Vector3(0,0,0); // sets the position of the object to your mouth position
        noahbiteObject.transform.localEulerAngles = new Vector3(0, 0, 0); // sets the position of the object to your mouth position
    }

    void ChangeBiteToDestroyButton()
    {
        BiteButton.GetComponent<Image>().sprite = DestroyButtonMouseOver;
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
