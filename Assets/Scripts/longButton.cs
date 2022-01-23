using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class longButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Animator PlayerAnimm;

    public float ClickDuration = 1f;
    float totalDownTime = 0;
    public UnityEvent OnLongClick;

    public Button BiteButton;
    public Sprite BiteButtonImage;
    public Sprite BiteButtonMouseOver;
    public Sprite BiteButtonClicked; // PlayerScripts - MovePlayer 에서 버튼 이미지 BiteButtonImage 로 바꿈

    bool clicking = false;
    bool clickingTwice = false;
    private bool mouse_over = false;
    void ChangeBiteTrue()
    {
        PlayerAnimm.SetBool("IsBiting", true);
    }

    void ChangeBiteFalse()
    {
        PlayerAnimm.SetBool("IsBiting", false);
    }


    // Update is called once per frame
    void Update()
    {
        //if(/* 마우스 오버시*/)
        //{
        //    // 버튼 스프라이트 바꿈 : 마우스 오버 상태
        //}
        if (mouse_over)
        {
            Debug.Log("Mouse Over");
        }

        // Detect the first click
        if (Input.GetMouseButtonDown(0))
        {
            BiteButton.GetComponent<Image>().sprite = BiteButtonClicked;
  
            totalDownTime = 0;
            clicking = true;
            Invoke("ChangeBiteTrue", 0.5f);
            Invoke("ChangeBiteFalse", 2);
            
            // 버튼 스프라이트 바꿈 : 선택된 상태
            
        }

        // If a first click detected, and still clicking,
        // measure the total click time, and fire an event
        // if we exceed the duration specified
        if (clicking && Input.GetMouseButton(0))
        {
            totalDownTime += Time.deltaTime;

            if (totalDownTime >= ClickDuration)
            {
                Debug.Log("Long click");
                clicking = false;
                OnLongClick.Invoke();
            }
        }

        // If a first click detected, and we release before the
        // duraction, do nothing, just cancel the click
        if (clicking && Input.GetMouseButtonUp(0))
        {
            clicking = false;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        mouse_over = true;
        BiteButton.GetComponent<Image>().sprite = BiteButtonMouseOver;
        Debug.Log("Mouse enter");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        mouse_over = false;
        BiteButton.GetComponent<Image>().sprite = BiteButtonImage;
        Debug.Log("Mouse exit");
    }
}
