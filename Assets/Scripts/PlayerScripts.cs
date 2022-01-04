using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerScripts : MonoBehaviour
{
    private NavMeshAgent agent;
    private Camera mainCamera;

    private bool turning;
    private Quaternion targetRot;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    { // 왼쪽 마우스 클릭 && 마우스가 UI 위에 있지 않음
        if(Input.GetMouseButtonDown(0)&&!Extensions.IsMouseOverUI())
        {
           Onclick(); 
        }

        if(turning&&transform.rotation!=targetRot)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, 15f * Time.deltaTime);
        }
        
    }

    void Onclick()
    {
        RaycastHit hit;
        Ray camToScreen = mainCamera.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(camToScreen, out hit, Mathf.Infinity))
        {
            if(hit.collider!=null)
            {
                Interactable interactable = hit.collider.GetComponent<Interactable>();
                if(interactable!=null)
                {   
                    MovePlayer(interactable.InteractPosition());
                    interactable.Interact(this);
                }
                else
                {
                    MovePlayer(hit.point);
                }
            }
        }

    }
    public bool CheckIfArrived()
    {
        // NavMeshAgent.pathPending : 계산 중이지만 아직 준비가 되지 않은 경로 -> false 면 계산 완료되었다는 뜻
        // 경로가 계산완료됨 && 목적지로 가고 있음 -> 참 반환
        return (!agent.pathPending&&agent.remainingDistance<=agent.stoppingDistance);
    }

    void MovePlayer(Vector3 targetPosition)
    {
        turning = false;
       agent.SetDestination(targetPosition);
    }

    public void SetDirection(Vector3 targetDirection)
    {
        turning = true;
        targetRot = Quaternion.LookRotation(targetDirection - transform.position);

    }
}


