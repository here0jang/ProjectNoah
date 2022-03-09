using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//// < > : 변화가 있는 상호작용 오브젝트 ex. <조종실 문>
//// [ ] : 그자체는 변화가 없는 상호작용 오브젝트 ex. [박스], [막대기]
//// ( ) : UI 요소 ex. (AI 상태창)
//// " " : 상호작용 ex. "누르기", "냄새맡기"

public class M_C1_CockpitOpen : MonoBehaviour
{
    private GameObject nowObject;

    /* 이번 플로우차트에서 저장되는 설정들 */
    public static bool IsAI = false;
    public static bool IsCockpitDoorOpen = false;

    /* 이번 플로우차트에서 쓰이는 오브젝트 목록 */
    private GameObject consoleLeft;
    private GameObject box;
    private GameObject envirPipe;
    private GameObject ConsoleLeftAIResetButton;

    public GameObject consoleButtonDescription;

    private GameObject cockpitDoor;

    private void Start()
    {
        // 잠들어 있던 노아가 깨어난다 && 화면이 밝아진다
        if (IsAI)
        {
            // AI UI 활성화
        }
        if(IsCockpitDoorOpen)
        {
            // 문 열려있고 & changeMap 활성화
        }
    }

    private void Update()
    {
        nowObject = PlayerScripts.playerscripts.currentObject;
    }

    //public bool ResetAI()
    //{
    //    if (nowObject.name == "Console_Left")
    //    {
    //        consoleLeft = nowObject;
    //        ObjData consoleLeftData = consoleLeft.GetComponent<ObjData>();
    //        if(consoleLeftData != null)
    //        {
    //            if(consoleLeftData.IsObserve)
    //            {
    //                //@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
    //                if(nowObject.name == "Box")
    //                {
    //                    box = nowObject;
    //                    ObjData boxData = box.GetComponent<ObjData>();
    //                    if(boxData != null)
    //                    {
    //                        if(boxData.IsUp)
    //                        {
    //                            CameraController.cameraController.currnentView = consoleLeftData.ObserveBoxView;
    //                            //관찰 뷰 : < 시스템 재가동 버튼> 이 보이는 위치
    //                            consoleButtonDescription.SetActive(true);
    //                            //@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
    //                            if (nowObject.name == "EnvirPipe")
    //                            {
    //                                envirPipe = nowObject;
    //                                ObjData envirPipeData = envirPipe.GetComponent<ObjData>();
    //                                if(envirPipeData!=null)
    //                                {
    //                                    if(envirPipeData.IsBite)
    //                                    {
    //                                        // < 시스템 재가동 버튼> "누르기" 버튼 활성화
    //                                        //@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
    //                                        if (nowObject.name == "Console_Left_ResetButton")
    //                                        {
    //                                            ConsoleLeftAIResetButton = nowObject;
    //                                            ObjData ConsoleLeftAIResetButtoneData = ConsoleLeftAIResetButton.GetComponent<ObjData>();
    //                                            {
    //                                                if (ConsoleLeftAIResetButtoneData != null)
    //                                                {
    //                                                    if(ConsoleLeftAIResetButtoneData.IsPushOrPress)
    //                                                    {
    //                                                        IsAI = true;
    //                                                        //AI : n1 번째 대사 묶음 출력 // (눌렀을 때 반응들 델리게이트로 한번에 호출??)
    //                                                        //@@ <시스템 재가동 버튼> 상호작용 비활성화(이후에 누르는 일 없도록) @@
    //                                                        return true; //@@@@ 엔딩 수집 페이지 갱신, 게임 세이브 분기점 @@@@@@@
    //                                                    }
    //                                                }
    //                                            }
    //                                        }
    //                                    }
    //                                }
    //                            }
    //                        }
    //                        else
    //                        {
    //                            // 관찰 뷰 : 안보이는 위치
    //                        }
    //                    }
    //                }
    //                else
    //                {
    //                    // 관찰 뷰 : 안보이는 위치
    //                }
    //            }
    //        }
    //    }
    //}


    //public bool OpenCockpitDoor()
    //{
    //    if(IsAI && /* 문에 가까이가면 */)
    //    {
    //        //(UI) AI : n2 번째 대사 묶음 출력
    //        if (/*[파이프] 를 "물기"*/)
    //        {
    //            //상호작용 버튼 : 가운데 "끼우기" 활성화
    //            if (/*[파이프] 를 <문> 에 "끼우기"*/)
    //            {
    //                //문에 파이프 끼우기 미니게임 활성화
    //                if (/*미니게임 성공*/)
    //                {
    //                    //노아 멈춤
    //                    if (/*문 주변 클릭*/)
    //                    {
    //                        //노아 이동
    //                        //문 열림, 
    //                        //업무공간 이동 가능
    //                        IsCockpitDoorOpen = true; //조종실 문 열려있음 고정
    //                        return true; //@@@@ 엔딩 수집 페이지 갱신, 게임 세이브 분기점 @@@@@@@
    //                        // @@@@@@@ 다음 플로우차트 활성화 @@@@@@@@
    //                    }
    //                }
    //            }
    //        }
    //    }
    //}
}