//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class NewBehaviourScript : MonoBehaviour
//{
//     // Detect the first click
//        if (Input.GetMouseButtonDown(0))
//        {
//            isBiteButton = true;
//            biteButton.GetComponent<Image>().sprite = BiteButtonClicked; // ��ư ��������Ʈ �ٲ� : ���õ� ����

//            totalDownTime = 0;
//            clicking = true;
//            Invoke("ChangeBiteTrue", 0.5f);
//            Invoke("ChangeBiteFalse", 2);

//            //if (Physics.Raycast(ray, out hit, Mathf.Infinity))
//            //{
//            //    if(hit.transform.tag == "BiteButton1")/*����ĳ��Ʈ�� ģ ������Ʈ�� Bite Button �̸� */
//            //    {
//            //        isBiteButton = true;
//            //        biteButton.GetComponent<Image>().sprite = BiteButtonClicked; // ��ư ��������Ʈ �ٲ� : ���õ� ����

//            //        totalDownTime = 0;
//            //        clicking = true;
//            //        Invoke("ChangeBiteTrue", 0.5f);
//            //        Invoke("ChangeBiteFalse", 2);
//            //    }
//            //}  
//        }

//        // If a first click detected, and still clicking,
//        // measure the total click time, and fire an event
//        // if we exceed the duration specified
//        if (isBiteButton && clicking && Input.GetMouseButton(0))
//        {
//            totalDownTime += Time.deltaTime;

//            if (totalDownTime >= ClickDuration)
//            {
//                Debug.Log("Long click");
//                clicking = false;
//                isBiteButton = false;
//                OnLongClick.Invoke();
//            }
//        }

//        // If a first click detected, and we release before the
//        // duraction, do nothing, just cancel the click
//        if (clicking && Input.GetMouseButtonUp(0))
//        {
//            clicking = false;
//            isBiteButton = false;
//        }

//}