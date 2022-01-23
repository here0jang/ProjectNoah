using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LongClickButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
	private bool pointerDown;
	private float pointerDownTimer;

	[SerializeField] float requiredHoldTime = 1f;

	public UnityEvent onLongClick;
	public UnityEvent onClick;

	//[SerializeField]
	//private Image fillImage;

	public void OnPointerDown(PointerEventData eventData)
	{
		pointerDown = true;
		Debug.Log("OnPointerDown");
	}

	public void OnPointerUp(PointerEventData eventData)
	{
		Reset();
		Debug.Log("OnPointerUp");
	}

	private void Update()
	{
		if (pointerDown)
		{
			pointerDownTimer += Time.deltaTime;
			if (pointerDownTimer >= requiredHoldTime)
			{
				if (onLongClick != null)
					onLongClick.Invoke();

				Reset();
			}

			//fillImage.fillAmount = pointerDownTimer / requiredHoldTime;
		}
	}

	private void Reset()
	{
		pointerDown = false;
		pointerDownTimer = 0;
		//fillImage.fillAmount = pointerDownTimer / requiredHoldTime;
	}



}


//public Button biteButton, destroyButton;
////버튼이 클릭된 상태 && 누른지 2초이상이면
//public void OnLongClick()
//{
//	biteButton.transform.gameObject.SetActive(false);
//	destroyButton.transform.gameObject.SetActive(true);
//}
