using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CancelInteractions : MonoBehaviour
{
    private float objectDistance = 1f;
    public NavMeshAgent Agent;
    public Animator playerAnimation;

    public GameObject noahPosition;
    public GameObject moveableGroup;
    private GameObject climbObject, biteObject, pushObject, noahNovepushobject;

    void Update()
    {
        /* 나중에 상호작용 여러 개 취소 할 때 취소 순서도 넣을 것. ex. 오르기+물기 -> 1) 내려와서 2) 내려놓기 */
        if (Input.GetMouseButtonDown(1))
        {
            /* 관찰하기 취소 */
            if (InteractionButtonController.interactionButtonController.isObserve)
            {
                CameraController.cameraController.CancelObserve();
                InteractionButtonController.interactionButtonController.isObserve = false;
            }

            /* 오르기 취소 */
            if (InteractionButtonController.interactionButtonController.isGround == false)
            {
                climbObject = InteractionButtonController.interactionButtonController.noahClimbObject;
                if (Agent.enabled)
                {
                    noahPosition.transform.position = new Vector3(climbObject.transform.localPosition.x, 33.78f, climbObject.transform.localPosition.z);
                    Agent.updatePosition = true;
                    Agent.updateRotation = true;
                    Agent.isStopped = false;
                }
                InteractionButtonController.interactionButtonController.isGround = true;
            }

            /* 밀기 취소 */
            if (InteractionButtonController.ISPUSH)
            {
                pushObject = InteractionButtonController.interactionButtonController.noahPushObject;
                noahNovepushobject = SaveDataWhenSceneChange.savedata.obj;

                if (pushObject != null)
                {
                    playerAnimation.SetBool("IsPushing", false);
                    pushObject.transform.SetParent(null, true);
                    pushObject.transform.parent = moveableGroup.transform;
                    InteractionButtonController.interactionButtonController.ispush = false;
                }

                if(noahNovepushobject!=null)
                {
                    playerAnimation.SetBool("IsPushing", false);
                    noahNovepushobject.transform.SetParent(null, true);
                    noahNovepushobject.transform.parent = moveableGroup.transform; // 다시 무바블오브젝트의 자식으로 넣기
                    InteractionButtonController.interactionButtonController.ispush = false;
                }               
            }

            /* 물기 취소 */
            if (BiteDestroyButtonController.biteDestroyButtonController.isBite)
            {
                biteObject = BiteDestroyButtonController.biteDestroyButtonController.noahBiteObject;
                if (biteObject != null)
                {
                    playerAnimation.SetBool("IsPutDowning", true);
                    Invoke("CancelBitingAnimation", 1f);
                    Invoke("PutDownObject", 0.5f);
                    BiteDestroyButtonController.biteDestroyButtonController.isBite = false;
                }
            }
        }
    }

    void CancelBitingAnimation()
    {
        playerAnimation.SetBool("IsPutDowning", false);
    }
    void PutDownObject()
    {
        biteObject.GetComponent<Rigidbody>().isKinematic = false; 
        biteObject.transform.parent = null;
        biteObject.transform.position = new Vector3(biteObject.transform.position.x, 33.799f, biteObject.transform.position.z);
    }                                                                                                                                                                                                                                                                                                                                                                                                                                                     
}

//biteObject.transform.position = new Vector3(noahPosition.gameObject.transform.position.x, 33.799f, noahPosition.gameObject.transform.position.z);
//biteObject.transform.rotation = Quaternion.Euler(0, noahPosition.gameObject.transform.rotation.y + 90, 0);
