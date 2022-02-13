using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerScripts : MonoBehaviour
{
    public InventoryObject inventory;
    public static PlayerScripts playerscripts { get; private set; }
    private NavMeshAgent agent;

    private Camera mainCamera;

    private bool turning; // default : false
    private Quaternion targetRot; // 플레이어의 처음 각도

    private Vector3 PlayerPosition, NPCPosition = new Vector3();
    private float DistanceBetweenPlayerandNPC = 25f; /* 플레이어와 NPC 사이의 거리가 얼마나 가까우면 상호작용 버튼 나타나게 할지 */

    public Button barkButton, pushButton, observeButton, sniffButton, centerDisableButton;
    public GameObject biteButton;
    public Sprite BiteButtonimage;
    private PlayerAnimation playerAnim = new PlayerAnimation();

    private string smelltext;
    private Button centerbutton;
    private Transform observeview;
    private GameObject noahbiteobject;
    private GameObject noahpushobject;
    private Vector3 interactionbuttonposition;

    public GameObject InteractionButtons;


    public GameObject CurrentObject;



    public string transferMapName;

    private void Awake()
    {
        playerscripts = this;
    }

    void Start()
    {
        mainCamera = Camera.main; // Scene 에서 MainCamera 라고 Tag 가 첫번째로 활성화된 카메라를 나타냄
        agent = GetComponent<NavMeshAgent>();
        // Player 에 없으므로 
        playerAnim.Init(GetComponentInChildren<Animator>()); // Player 의 자식인 noah_FBX 에 붙어있는 컴포넌트인 animator 초기화
    }

    // Update is called once per frame
    void Update()
    {      
        // 왼쪽 마우스 클릭 && 마우스가 UI 위에 있지 않음
        if(Input.GetMouseButtonDown(0)&&!Extensions.IsMouseOverUI())
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
        RaycastHit hit; //  충돌이 일어나면 코드 실행, 
        Ray camToScreen = mainCamera.ScreenPointToRay(Input.mousePosition);
        // 왼쪽 마우스 클릭을 감지하면      // Q, 이거랑 아래 hit.collider!=nulll 한번에 쓰면 안됨?? 
        if (Physics.Raycast(camToScreen, out hit, Mathf.Infinity)) // out??
        {
            if (hit.collider != null) // 무언가를 치면
            {

                PlayerPosition = this.gameObject.transform.position;
                noahpushobject = hit.collider.gameObject;
                Interactable interactable = hit.collider.GetComponent<Interactable>(); // interactable : 부딪힌 오브젝트 or NPC 에 붙어있는 Interactable 컴포넌트         
                ObjData objData = hit.collider.GetComponent<ObjData>();

                if (objData != null)
                {
                    smelltext = objData.SmellText;
                    centerbutton = objData.CenterButton;
                    observeview = objData.ObserveView;

                    noahbiteobject = objData.PlayerBiteObject;
                    noahpushobject = objData.PlayerPushObject;
                    interactionbuttonposition = objData.InteractionButtonPosition;
                    InteractionButtons.gameObject.transform.position = interactionbuttonposition;
                }

                if (interactable != null) // 부딪힌 오브젝트에 interactable 컴포넌트가 붙어있으면
                {
                    CurrentObject = hit.collider.gameObject;
                    NPCPosition = interactable.transform.position;
                    Vector3 offset = PlayerPosition - NPCPosition;
                    float sqrLen = offset.sqrMagnitude; // 플레이어의 이동 전 현재 위치와 오브젝트 사이의 거리


                    MovePlayer(interactable.InteractPosition()); // NPC 의 위치로 플레이어를 이동시킴

                    if (sqrLen < DistanceBetweenPlayerandNPC)
                    {
                        //InteractionButtons.transform.position = new Vector3(buttonPosition.x, buttonPosition.y, 0);
                        interactable.Interact(this); // this : PlayerScript 전달 ( argument ), 현재 PlayerScript 에 있으므로 this 로 전달 가능
                    } // 순서가 : PlayerScripts 에서 NPC 클릭 -> Interactable 스크립트 - Interact - actions -> messageAction 실행 - > DialogSystem - ShowMessages 실행 
                }


                else // 상호작용 가능한 오브젝트가 아니면 플레이어만 이동시킴. 
                {
                    MovePlayer(hit.point); // hit.point : 이동 목적지
                    if (hit.collider.name == "Door")
                    {
                        Invoke("ChangePlayerScene", 2f);
                    }
                }
            }
        }

    }
    public string PlayerSmellText { get { return smelltext; } }

    public Button ObjectCenterButton { get { return centerbutton; } }
    //public bool ObjectIsObserve { get { return isobserve; } }
    public Transform PlayerobserveView { get { return observeview; } }
    public GameObject PlayerNoahBiteObject { get { return noahbiteobject; } }
    public GameObject PlayerNoahPushObject { get { return noahpushobject; } }
    

    public Vector3 PlayerInteractionButtonPosition { get { return interactionbuttonposition; } }

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
        biteButton.GetComponent<Image>().sprite = BiteButtonimage;
        biteButton.transform.gameObject.SetActive(false);
        barkButton.transform.gameObject.SetActive(false);
        pushButton.transform.gameObject.SetActive(false);
        observeButton.transform.gameObject.SetActive(false);
        sniffButton.transform.gameObject.SetActive(false);
        centerDisableButton.transform.gameObject.SetActive(false);
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
    private void OnApplicationQuit()
    {
        inventory.Container.Clear();
    }
}


