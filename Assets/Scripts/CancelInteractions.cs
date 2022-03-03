using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CancelInteractions : MonoBehaviour
{
    private float objectDistance = 1f;
    public GameObject NoahPosition;
    public Animator PlayerAnimation;
    private GameObject noahbiteobject;
    private GameObject noahpushobject;
    private GameObject noahNovepushobject;
    public NavMeshAgent Agent;
    public GameObject moveableGroup;

    public 
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            cam.newCam.CancelObserve();
            if (longButton.ISPUSH)
            {
                noahpushobject = longButton.longbutton.noahpushObject;
                noahNovepushobject = SaveDataWhenSceneChange.savedata.obj;

                if (noahpushobject != null)
                {
                    PlayerAnimation.SetBool("IsPushing", false);
                    noahpushobject.transform.SetParent(null, true);
                    noahpushobject.transform.parent = moveableGroup.transform;
                    longButton.longbutton.ispush = false;
                    Agent.radius = 0.75f;
                }

                if(noahNovepushobject!=null)
                {
                    PlayerAnimation.SetBool("IsPushing", false);
                    noahNovepushobject.transform.SetParent(null, true);
                    noahNovepushobject.transform.parent = moveableGroup.transform; // 다시 무바블오브젝트의 자식으로 넣기

                    longButton.longbutton.ispush = false;
                    Agent.radius = 0.75f;
                }

                
            }

            //if (BiteDestroyButton.bitedestroybutton.ISBITE)
            //{
            //    noahbiteobject = BiteDestroyButton.bitedestroybutton.noahbiteObject;
            //    if (noahbiteobject != null)
            //    {
            //        noahbiteobject.GetComponent<Rigidbody>().isKinematic = false; // make the rigidbody work again
            //                                                                      //noahbiteobject.GetComponent<Rigidbody>().useGravity = true;
            //        noahbiteobject.transform.parent = null; // make the object no be a child of the hands           
            //        noahbiteobject.transform.position = new Vector3(NoahPosition.gameObject.transform.position.x, 33.799f, NoahPosition.gameObject.transform.position.z);

            //        noahbiteobject.transform.rotation = Quaternion.Euler(0, NoahPosition.gameObject.transform.rotation.y + 90, 0);
            //        BiteDestroyButton.bitedestroybutton.ISBITE = false;
            //    }
            //}
            if (longButton.longbutton.isGrounded == false)
            {
                noahpushobject = longButton.longbutton.noahpushObject;
                if (Agent.enabled)
                {
                    NoahPosition.transform.position = new Vector3(noahpushobject.transform.localPosition.x, 33.78f, noahpushobject.transform.localPosition.z);
                    Agent.updatePosition = true;
                    Agent.updateRotation = true;

                }

                longButton.longbutton.isGrounded = true;
            }

        }
    }

}
