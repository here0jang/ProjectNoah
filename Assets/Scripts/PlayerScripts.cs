using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerScripts : MonoBehaviour
{
    /* 싱글턴 */
    public static PlayerScripts playerscripts { get; private set; }
    private void Awake()
    {
        playerscripts = this;
    }

    private NavMeshAgent agent;
    private Camera mainCamera;
    private PlayerAnimation playerAnim = new PlayerAnimation();

    private bool turning; // default : false
    private Quaternion targetRot; // 플레이어의 처음 각도

    /* 플레이어와 NPC 사이의 거리를 측정하여 일정 거리 이하일 때만 상호작용 버튼 생성 위한 변수 */
    private Vector3 playerPosition, interactObjectPosition = new Vector3();
    private const float DistanceBetweenPlayerandObject = 25f;

    /* 상호작용 오브젝트로부터 받아온 데이터 담는 변수 */
    private string smellData;
    private Button pushOrPressButtonData, centerButtonData;
    private GameObject biteObjectData, pushObjectData, climbObjectData;
    private Transform observeData, ObservePlusData; // ObservePlusData : 박스 위에서 관찰 등
    private Vector3 interactButtonPositionData;

    /* 해당 플로우차트에 넘길 상호작용 오브젝트 변수 */
    public GameObject currentObject;

    /* 문 클릭 시 이동할 씬*/
    public string transferMapName;

    /* bite ~ destroy 버튼 예외 처리 */
    public GameObject biteButton;
    public Sprite BiteButtonimage;

    /* 오브젝트 위치가 변할 때마다 버튼 위치도 다시 정하기 위한 변수 */
    public GameObject interactionButtons;


    //@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
    /* 전부 플로우차트로 옮기기 */
    public bool IsDoorLocked = true;
    public bool IsDoorClicked= false;
    public bool isPipeInserted = false;
    public GameObject DoorClickArea;
    public bool isDoorClickAreaClicked = false;
    //@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@




    void Start()
    {
        mainCamera = Camera.main; // Scene 에서 MainCamera 라고 Tag 가 첫번째로 활성화된 카메라를 나타냄
        agent = GetComponent<NavMeshAgent>();
        playerAnim.Init(GetComponentInChildren<Animator>()); // Player 의 자식인 noah_FBX 에 붙어있는 컴포넌트인 animator 초기화
    }

    void Update()
    {      
        // 왼쪽 마우스 클릭 && 마우스가 UI 위에 있지 않음
        if(Input.GetMouseButtonDown(0)&&!Extensions.IsMouseOverUI()&&(!agent.isStopped))
        {
           Onclick(); 
        }
        // 회전하는 중이고(참) && 플레이어의 현재 각도와 초기 각도가 다르면??  // Q. 여기 if 문이 뭔일하는지 솔직히 모르겠음
        if(turning&&transform.rotation!=targetRot)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, 15f * Time.deltaTime); // a 각도와 b 각도 사이를 보간해줌
        }
        // NavMeshAgent 의 Velocity 전달, vector --> magnitude
        playerAnim.UpdateAnimation(agent.velocity.sqrMagnitude); // 두 점간의 거리     
    }

    void Onclick()
    {
        RaycastHit hit;
        Ray camToScreen = mainCamera.ScreenPointToRay(Input.mousePosition); // 레이저가 나가는 위치 : 왼쪽 마우스
        if (Physics.Raycast(camToScreen, out hit, Mathf.Infinity))
        {
            if (hit.collider != null) // 무언가를 치면 (상호작용 오브젝트 + 바닥)
            {
                playerPosition = this.gameObject.transform.position; // 플레이어의 이동 전 현재 위치
                pushObjectData = hit.collider.gameObject;

                Interactable interactable = hit.collider.GetComponent<Interactable>(); // interactable : 부딪힌 오브젝트 or NPC 에 붙어있는 Interactable 컴포넌트         
                ObjData objData = hit.collider.GetComponent<ObjData>();

                if (objData != null)
                {
                    smellData = objData.SmellText;
                    pushOrPressButtonData = objData.PushOrPressButton;
                    centerButtonData = objData.CenterButton;
                    observeData = objData.ObserveView;
                    ObservePlusData = objData.ObserveBoxView;
                    biteObjectData = objData.PlayerBiteObject;
                    pushObjectData = objData.PlayerPushObject;
                    climbObjectData = objData.PlayerClimbObject;
                    interactButtonPositionData = objData.InteractionButtonPosition;
                }

                if (interactable != null) // 부딪힌게 상호작용 오브젝트 일 때 
                {
                    interactObjectPosition = interactable.transform.position; // 상호작용 오브젝트의 위치

                    float interactButtonPositionX = 750 + 42 * (interactObjectPosition.x - 5);

                    /* "관찰하기" 뷰에서 상호작용 버튼을 띄우는 오브젝트들 예외 처리 (탑뷰 : X축, Z축, 관찰하기 뷰 : Y축, Z축) */
                    if (hit.collider.name == "Console_Left_ResetButton" || hit.collider.name == "Console_Left_UnLockButton")
                    {
                        interactionButtons.gameObject.transform.position = new Vector3(interactButtonPositionData.x, interactButtonPositionData.y, 0);
                    }
                    else
                    {
                        interactionButtons.gameObject.transform.position = new Vector3(interactButtonPositionX, interactButtonPositionData.y, 0); // 버튼이 오브젝트 위치를 따라다니게 함
                    }
                    Vector3 offset = playerPosition - interactObjectPosition; // 플레이어의 이동 전 현재 위치와 오브젝트 사이의 거리
                    float sqrLen = offset.sqrMagnitude; 

                    MovePlayer(interactable.InteractPosition()); // NPC 의 위치로 플레이어를 이동시킴

                    /* 플레이어와 오브젝트 사이의 거리가 가까우면 상호작용 버튼 생성 */
                    if (sqrLen < DistanceBetweenPlayerandObject)
                    {
                        currentObject = hit.collider.gameObject; /* 플로우차트 스크립트에 정보 넘김 */
                        //@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
                        if (currentObject.name == "DoorLocked")
                        {
                            IsDoorClicked = true;
                            if (IsDoorLocked)
                            {
                                DialogManager.dialogManager.DoorLock();
                            }
                        }
                        if (hit.collider.name == "DoorUnLocked" && UnLockDoor.unlockDoor.isDoorPipeInserted)
                        {
                            isPipeInserted = true;
                            DoorClickArea.SetActive(true);
                            Time.timeScale = 0;

                        }
                        if (hit.collider.name == "OpenDoorClickArea")
                        {
                            isDoorClickAreaClicked = true;
                            DoorClickArea.SetActive(false);
                        }
                        //@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@





                        interactable.Interact(this); // this : PlayerScript 전달 ( argument )
                    } 
                }
                else // 클릭한 곳이 바닥일 때(클릭한 위치로 이동) 
                {
                    MovePlayer(hit.point); // hit.point : 목적지

                    /* 예외로 다른 맵으로 이동할 때만 여기서 처리 (인터렉터블 컴포넌트가 붙어있지 많으므로 ) */
                    if (hit.collider.name == "ChangeMap")
                    {
                        Invoke("ChangePlayerScene", 1f);
                    }
                }
            }
        }
        // 순서가 : PlayerScripts 에서 NPC 클릭 -> Interactable 스크립트 - Interact - actions -> messageAction 실행 - > DialogSystem - ShowMessages 실행 
    }
    public string PlayerSmellText { get { return smellData; } }
    public Button ObjectpushOrpressbutton { get { return pushOrPressButtonData; } }
    public Button ObjectCenterButton { get { return centerButtonData; } }
    public Transform PlayerobserveView { get { return observeData; } }
    public Transform PlayerobserveBoxView { get { return ObservePlusData; } }
    public GameObject PlayerNoahBiteObject { get { return biteObjectData; } }
    public GameObject PlayerNoahPushObject { get { return pushObjectData; } }
    public GameObject PlayerNoahClimbObject { get { return climbObjectData; } }
    public Vector3 PlayerInteractionButtonPosition { get { return interactButtonPositionData; } }

    /*  플레이어가 목적지에 도착하면 True 를 반환하는 메서드  */
    public bool CheckIfArrived()
    {
        // NavMeshAgent.pathPending : 계산 중이지만 아직 준비가 되지 않은 경로 -> false 면 계산 완료되었다는 뜻
        // 경로가 계산완료됨 && 남은거리보다 감속거리가 더 큼 -> 참 반환
        return (!agent.pathPending && agent.remainingDistance<=agent.stoppingDistance);
    }

    void MovePlayer(Vector3 targetPosition)
    {
        turning = false; // 움직일때마다 turning 을 거짓으로 만듬
        agent.SetDestination(targetPosition);
        DialogSystem.Instance.HideDialog(); // 대화 도중에 움직이면 대화창을 끔
        IsDoorClicked = false;
        biteButton.GetComponent<Image>().sprite = BiteButtonimage;
        InteractionButtonController.interactionButtonController.TurnOffInteractionButton();
    }

    /* 플레이어가 NPC 를 바라보도록 각도를 바꿔주는 메서드 */
    public void SetDirection(Vector3 targetDirection) // targetDirection : NPC 의 각도
    {
        turning = true;
        targetRot = Quaternion.LookRotation(targetDirection - transform.position);
    }

    void ChangePlayerScene()
    {
        SceneManager.LoadScene(transferMapName);
    }

    /* 이 메서드가 없으면 스크립터블 오브젝트는 프로그램이 종료되어도 저장한 것을 계속 저장함 */
    //private void OnApplicationQuit()
    //{
    //    inventory.Container.Clear();
    //}
}


