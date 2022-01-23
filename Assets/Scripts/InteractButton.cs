using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractButton : MonoBehaviour
{
    public Animator PlayerAnim;
    public Button barkButton, pushButton, observeButton, sniffButton, destroyButton;
    public GameObject biteButton;

    void Awake()
    {
        barkButton.onClick.AddListener(playerBark);
        sniffButton.onClick.AddListener(playerSniff);
        observeButton.onClick.AddListener(playerObserve);

        


        pushButton.onClick.AddListener(playerPush);

        //biteButton.onClick.AddListener(playerBite);

        destroyButton.onClick.AddListener(playerDestroy);

    }

    void TurnOffInteractionButton()
    {
        barkButton.transform.gameObject.SetActive(false);
        pushButton.transform.gameObject.SetActive(false);
        observeButton.transform.gameObject.SetActive(false);
        sniffButton.transform.gameObject.SetActive(false);
        //biteButton.transform.gameObject.SetActive(false);
        destroyButton.transform.gameObject.SetActive(false);
    }
    //&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&

    void playerBite()
    {
        //TurnOffInteractionButton();
        Invoke("ChangeBiteTrue", 0.5f);
        Invoke("ChangeBiteFalse", 2);

        //Invoke("ChangeBiteToDestroy", 2);

    }

    void ChangeBiteTrue()
    {
        PlayerAnim.SetBool("IsBiting", true);
    }

    void ChangeBiteFalse()
    {
        PlayerAnim.SetBool("IsBiting", false);
    }

    void ChangeBiteToDestroy()
    {
        destroyButton.transform.gameObject.SetActive(true);
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
