using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractButton : MonoBehaviour
{
    public Animator PlayerAnim;
    public Button barkButton, pushButton, observeButton, sniffButton, upButton;

    void Awake()
    {
        barkButton.onClick.AddListener(playerBark);
        
    }

    void playerBark()
    {
        PlayerAnim.SetBool("IsBarking", true);
        StartCoroutine("ChangeBarkFalse");
    }

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

}
