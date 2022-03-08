﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//// < > : 변화가 있는 상호작용 오브젝트 ex. <조종실 문>
//// [ ] : 그자체는 변화가 없는 상호작용 오브젝트 ex. [박스], [막대기]
//// ( ) : UI 요소 ex. (AI 상태창)
//// " " : 상호작용 ex. "누르기", "냄새맡기"

public class M_C1_CockpitOpen : MonoBehaviour
{

}
//{
//    public static bool IsAI = false;
//    public static bool Is_M_C1_CockpitOpen()
//    {
//        // 잠들어 있던 노아가 깨어난다 && 화면이 밝아진다

//        if(/* <조종석> "관찰하기" == true */)
//        {
//            if(/* [박스] "오르기" == true */)
//            {
//                // 관찰 뷰 : < 시스템 재가동 버튼> 이 보이는 위치
//            }
//            else
//            {
//                // 관찰 뷰 : 안보이는 위치
//            }
//        }
//    	/* <조종장치> */
//    	if(IsCockpitObserve_BoxRise()) /*[박스] 위에 올라가서 "관찰하기"*/
//        {
//            // 관찰 뷰 : < 시스템 재가동 버튼> 이 보이는 위치에서 관찰
//            if(/* <조종석>에서 "관찰하기" == true */)
//            {
//                if (/*[파이프] 를 "물기" == true*/)
//                {
//                    //< 시스템 재가동 버튼> "누르기" 버튼 활성화
//                    if (/*< 시스템 재가동 버튼> "누르기" == true */)
//                    {
//                        IsAI = true; //@@ UI – AI 활성화 고정 @@
//                        // AI : n1 번째 대사 묶음 출력 // (눌렀을 때 반응들 델리게이트로 한번에 호출??)
//                        //@@ <시스템 재가동 버튼> 상호작용 비활성화(이후에 누르는 일 없도록) @@
//                    }
//                }
//                else (/*파이프를 안 물었음, 파이프말고 딴 걸 물었음, 파이프를 "밀기"함 등등*/)
//                {
//                    //< 시스템 재가동 버튼> "누르기" 버튼 비활성화
//                }
//            }
//        }
//        else
//        {
//            if()
//            //<시스템 재가동 버튼>이 보이지 않는 위치에서 관찰
//        }

//        /* <조종실 문> */
//        if (IsAI)
//        {   
//            //(UI) AI : n2 번째 대사 묶음 출력
//            if (/*[파이프] 를 "물기"*/)
//            {
//                //상호작용 버튼 : 가운데 "끼우기" 활성화
//                if (/*[파이프] 를<문> 에 "끼우기"*/)
//                {
//                    //문에 파이프 끼우기 미니게임 활성화
//                    if (/*미니게임 성공*/)
//                    {
//                        //노아 멈춤
//                        if (/*문 주변 클릭*/)
//                        {
//                            //노아 이동, 문 열림, 업무공간 이동 가능
//                            //조종실 문 열려있음 고정
//                            return true; // @@엔딩 수집 페이지 변경, 다음 퍼즐 시작에 사용@@
//                        }
//                    }
//                }
//            }
//        }                                               	      
//    }

//    public static bool IsCockpitObserve_BoxRise()
//    {
//        if(/* 박스가 조종석과 부딛힘 && 박스 위로 오르기 */)
//        {
//            // 관찰하기 뷰 : 박스 위
//            return true;
//        }
//    }
//}