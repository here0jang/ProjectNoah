using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class longButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] float requiredHoldTime = 1f;
    [SerializeField] float requiredChangeTime = 0.5f;
    float pointerDownTimer = 0;

    public Sprite BiteButtonImage;
    public Sprite BiteButtonMouseOver;
    public Sprite BiteButtonClicked; // PlayerScripts - MovePlayer 에서 버튼 이미지 BiteButtonImage 로 바꿈
    public Sprite DestroyButtonMouseOver;

    bool pointerDown = false;

    public Animator PlayerAnim;
    public Button barkButton, pushButton, observeButton, sniffButton, biteButton;

    [SerializeField] GameObject Noah;

    void Awake()
    {    
        barkButton.onClick.AddListener(playerBark);
        sniffButton.onClick.AddListener(playerSniff);
        observeButton.onClick.AddListener(playerObserve);

        pushButton.onClick.AddListener(playerPush);
    }

    private void Update()
    {
        if (pointerDown)
        {
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
        biteButton.GetComponent<Image>().sprite = BiteButtonMouseOver;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        biteButton.GetComponent<Image>().sprite = BiteButtonImage;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        biteButton.GetComponent<Image>().sprite = BiteButtonClicked;
        playerBite();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        pointerDown = true;
        Invoke("ChangeBiteTrue", 0.5f);
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

    void TurnOffInteractionButton()
    {
        barkButton.transform.gameObject.SetActive(false);
        pushButton.transform.gameObject.SetActive(false);
        observeButton.transform.gameObject.SetActive(false);
        sniffButton.transform.gameObject.SetActive(false);
        biteButton.transform.gameObject.SetActive(false);
    }
    //&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&

    void playerBite()
    {
        TurnOffInteractionButton();
        Invoke("ChangeBiteTrue", 0.5f);
        Invoke("ChangeBiteFalse", 2);
    }

    void ChangeBiteTrue()
    {
        PlayerAnim.SetBool("IsBiting", true);
    }

    void ChangeBiteFalse()
    {
        PlayerAnim.SetBool("IsBiting", false);
    }

    //&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&

    void playerBark()
    {
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
    }

    //&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&

    void playerPush()
    {
        TurnOffInteractionButton();
        Invoke("ChangePushTrue", 0.5f);
        Invoke("ChangePushFalse", 2);
    }

    void ChangePushTrue()
    {
        PlayerAnim.SetBool("IsPushing", true);
    }

    void ChangePushFalse()
    {
        PlayerAnim.SetBool("IsPushing", false);
    }

    //&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
    void ChangeBiteToDestroyButton()
    {
        biteButton.GetComponent<Image>().sprite = DestroyButtonMouseOver;
    }

    void playerDestroy()
    {
        TurnOffInteractionButton();
        Invoke("ChangeDestroyTrue", 0.5f);
        Invoke("ChangeDestroyFalse", 2);
    }

    void ChangeDestroyTrue()
    {
        PlayerAnim.SetBool("IsDestroying", true);
    }

    void ChangeDestroyFalse()
    {
        PlayerAnim.SetBool("IsDestroying", false);
    }
}
