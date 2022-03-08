using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BiteDestroyButtonController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{ 
    public static BiteDestroyButtonController biteDestroyButtonController { get; private set; }

    void Awake()
    {
        biteDestroyButtonController = this;
    }

    public Animator playerAnimation;

    bool isPointerDown = false;
    [SerializeField] float requiredHoldTime = 1f;
    [SerializeField] float requiredChangeTime = 0.5f;
    float pointerDownTimer = 0;

    public Button biteDestroyButton; // PlayerScripts - MovePlayer ���� ��ư �̹��� BiteButtonImage �� �ٲ�
    public Sprite biteButtonImage, biteButtonMouseOver, biteButtonClicked, destroyButtonMouseOver;

    public GameObject noahBiteObject;
    public GameObject myMouth;
    public bool isBite = false;


    void Update()
    {
        if (isPointerDown)
        {
            pointerDownTimer += Time.deltaTime;
            if (pointerDownTimer >= requiredChangeTime)
            {
                ChangeBiteToDestroyButton();

                Invoke("ChangeDestroyTrue", 1f);
                InteractionButtonController.interactionButtonController.TurnOffInteractionButton();
                Invoke("ChangeDestroyFalse", 3f);

                Reset();
            }
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        biteDestroyButton.GetComponent<Image>().sprite = biteButtonMouseOver;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        biteDestroyButton.GetComponent<Image>().sprite = biteButtonImage;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        InteractionButtonController.interactionButtonController.TurnOffInteractionButton();
        Reset();
    }

    private void Reset()
    {
        isPointerDown = false;
        pointerDownTimer = 0;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        biteDestroyButton.GetComponent<Image>().sprite = biteButtonClicked;
        isPointerDown = true;
        noahBiteObject = PlayerScripts.playerscripts.PlayerNoahBiteObject;

        Invoke("ChangeBiteTrue", 0.5f);
        Invoke("PlayerPickUp", 0.7f);
        Invoke("ChangeBiteFalse", 1);
    }

    void ChangeBiteTrue()
    {
        playerAnimation.SetBool("IsBiting", true);
    }

    void ChangeBiteFalse()
    {
        playerAnimation.SetBool("IsBiting", false);
    }

    void PlayerPickUp()
    {
        isBite = true;
        noahBiteObject.GetComponent<Rigidbody>().isKinematic = true;   //makes the rigidbody not be acted upon by forces
        noahBiteObject.GetComponent<Rigidbody>().useGravity = false;
        noahBiteObject.transform.parent = myMouth.transform; //makes the object become a child of the parent so that it moves with the mouth
        noahBiteObject.transform.localPosition = new Vector3(0,0,0); // sets the position of the object to your mouth position
        noahBiteObject.transform.localEulerAngles = new Vector3(0, 0, 0); // sets the position of the object to your mouth position
    }

    void ChangeBiteToDestroyButton()
    {
        biteDestroyButton.GetComponent<Image>().sprite = destroyButtonMouseOver;
    }

    void ChangeDestroyTrue()
    {
        playerAnimation.SetBool("IsDestroying", true);
    }

    void ChangeDestroyFalse()
    {
        playerAnimation.SetBool("IsDestroying", false);
    }

}