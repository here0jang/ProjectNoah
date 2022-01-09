using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerScripts : MonoBehaviour
{
    private NavMeshAgent agent;
    private Camera mainCamera;

    private bool turning; // default : false
    private Quaternion targetRot; // 플레이어의 처음 각도

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main; // Scene 에서 MainCamera 라고 Tag 가 첫번째로 활성화된 카메라를 나타냄
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    { // 왼쪽 마우스 클릭 && 마우스가 UI 위에 있지 않음
        if(Input.GetMouseButtonDown(0)&&!Extensions.IsMouseOverUI())
        {
           Onclick(); 
        }

        // 회전하는 중이고(참) && 플레이어의 현재 각도와 초기 각도가 다르면??  // Q. 여기 if 문이 뭔일하는지 솔직히 모르겠음
        if(turning&&transform.rotation!=targetRot)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, 15f * Time.deltaTime); // a 각도와 b 각도 사이를 보간해줌
        }
        
    }

    void Onclick()
    {
        RaycastHit hit; // Difference Between RaycastHit and Ray?? 
        Ray camToScreen = mainCamera.ScreenPointToRay(Input.mousePosition);

        // 왼쪽 마우스 클릭을 감지하면      // Q, 이거랑 아래 hit.collider!=nulll 한번에 쓰면 안됨?? 
        if(Physics.Raycast(camToScreen, out hit, Mathf.Infinity)) // out??
        {
            // 무언가를 치면
            if(hit.collider!=null)
            {
                // interactable : 부딪힌 오브젝트 or NPC 에 붙어있는 Interactable 컴포넌트
                Interactable interactable = hit.collider.GetComponent<Interactable>(); 

                if(interactable!=null) // 부딪힌 오브젝트에 interactable 컴포넌트가 붙어있으면
                {   
                    MovePlayer(interactable.InteractPosition()); // NPC 의 위치로 플레이어를 이동시킴
                    interactable.Interact(this); // this : PlayerScript 전달 ( argument ), 현재 PlayerScript 에 있으므로 this 로 전달 가능
                }
                else // 상호작용 가능한 오브젝트가 아니면 플레이어만 이동시킴. 
                {
                    MovePlayer(hit.point); // hit.point : 이동 목적지
                }
            }
        }

    }

    /*  플레이어가 목적지에 도착하면 True 를 반환하는 메서드  */
    public bool CheckIfArrived()
    {
        // NavMeshAgent.pathPending : 계산 중이지만 아직 준비가 되지 않은 경로 -> false 면 계산 완료되었다는 뜻
        // 경로가 계산완료됨 && 목적지로 가고 있음 -> 참 반환
        return (!agent.pathPending&&agent.remainingDistance<=agent.stoppingDistance);
    }

    void MovePlayer(Vector3 targetPosition)
    {
        turning = false; // 움직일때마다 turning 을 거짓으로 만듬
       agent.SetDestination(targetPosition);
        DialogSystem.Instance.HideDialog();
    }

    /* 플레이어가 NPC 를 바라보도록 각도를 바꿔주는 메서드 */
    public void SetDirection(Vector3 targetDirection) // targetDirection : NPC 의 각도
    {
        turning = true;
        targetRot = Quaternion.LookRotation(targetDirection - transform.position);

    }
}


