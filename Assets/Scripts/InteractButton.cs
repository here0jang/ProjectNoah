using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractButton : MonoBehaviour
{
    public Animator PlayerAnim;
    public Button barkButton, pushButton, observeButton, sniffButton, upButton;
    public string smellText = "Smells like tin spirit";

    void Awake()
    {
        barkButton.onClick.AddListener(playerBark);
        pushButton.onClick.AddListener(playerPush);
        observeButton.onClick.AddListener(playerObserve);
        sniffButton.onClick.AddListener(playerSniff);
        upButton.onClick.AddListener(playerUp);
    }

    void playerBark()
    {
        barkButton.transform.gameObject.SetActive(false);
        pushButton.transform.gameObject.SetActive(false);
        observeButton.transform.gameObject.SetActive(false);
        sniffButton.transform.gameObject.SetActive(false);
        upButton.transform.gameObject.SetActive(false);
        Invoke("ChangeBarkTrue", 0.5f);

        Invoke("ChangeBarkFalse", 2);
    }

    void ChangeBarkFalse()
    {
        PlayerAnim.SetBool("IsBarking", false);
    }

    void ChangeBarkTrue()
    {
        PlayerAnim.SetBool("IsBarking", true);
    }
    /*
    IEnumerator ChangeBarkFalse()
    {
        yield return new WaitForSeconds(2f);
        PlayerAnim.SetBool("IsBarking", false);

        barkButton.transform.gameObject.SetActive(false);
        pushButton.transform.gameObject.SetActive(false);
        observeButton.transform.gameObject.SetActive(false);
        sniffButton.transform.gameObject.SetActive(false);
        upButton.transform.gameObject.SetActive(false);
    }
    */

    void playerPush()
    {
        PlayerAnim.SetBool("IsPushing", true);
        StartCoroutine("ChangePushFalse");
    }

    IEnumerator ChangePushFalse()
    {
        yield return new WaitForSeconds(2f);
        PlayerAnim.SetBool("IsPushing", false);
        barkButton.transform.gameObject.SetActive(false);
        pushButton.transform.gameObject.SetActive(false);
        observeButton.transform.gameObject.SetActive(false);
        sniffButton.transform.gameObject.SetActive(false);
        upButton.transform.gameObject.SetActive(false);
    }
    void playerObserve()
    {
        PlayerAnim.SetBool("IsObserving", true);
        StartCoroutine("ChangeObserveFalse");
    }

    IEnumerator ChangeObserveFalse()
    {
        yield return new WaitForSeconds(2f);
        PlayerAnim.SetBool("IsObserving", false);
        barkButton.transform.gameObject.SetActive(false);
        pushButton.transform.gameObject.SetActive(false);
        observeButton.transform.gameObject.SetActive(false);
        sniffButton.transform.gameObject.SetActive(false);
        upButton.transform.gameObject.SetActive(false);
    }
    void playerSniff()
    {
        PlayerAnim.SetBool("IsSniffing", true);
        DialogSystem.Instance.Smell(smellText);
        StartCoroutine("ChangeSniffFalse");
    }

    IEnumerator ChangeSniffFalse()
    {
        yield return new WaitForSeconds(2f);
        PlayerAnim.SetBool("IsSniffing", false);
        barkButton.transform.gameObject.SetActive(false);
        pushButton.transform.gameObject.SetActive(false);
        observeButton.transform.gameObject.SetActive(false);
        sniffButton.transform.gameObject.SetActive(false);
        upButton.transform.gameObject.SetActive(false);
    }
    void playerUp()
    {
        PlayerAnim.SetBool("IsUping", true);
        StartCoroutine("ChangeUpFalse");
    }

    IEnumerator ChangeUpFalse()
    {
        yield return new WaitForSeconds(2f);
        PlayerAnim.SetBool("IsUping", false);
        barkButton.transform.gameObject.SetActive(false);
        pushButton.transform.gameObject.SetActive(false);
        observeButton.transform.gameObject.SetActive(false);
        sniffButton.transform.gameObject.SetActive(false);
        upButton.transform.gameObject.SetActive(false);
    }

}
