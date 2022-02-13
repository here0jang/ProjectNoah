using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CancelInteractions : MonoBehaviour
{
    public GameObject NoahPosition;
    public Animator PlayerAnimation;
    private GameObject noahbiteobject;
    private GameObject noahpushobject;
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            cam.newCam.CancelObserve();
            if (longButton.longbutton.ispush)
            {
                noahpushobject = longButton.longbutton.noahpushObject;
                if (noahpushobject != null)
                {
                    PlayerManager.playermanager.isPush = false;
                    PlayerAnimation.SetBool("IsPushing", false);
                    noahpushobject.transform.SetParent(null, true);
                    longButton.longbutton.ispush = false;
                }
            }

            if (BiteDestroyButton.bitedestroybutton.ISBITE)
            {
                noahbiteobject = BiteDestroyButton.bitedestroybutton.noahbiteObject;
                if (noahbiteobject != null)
                {
                    noahbiteobject.GetComponent<Rigidbody>().isKinematic = false; // make the rigidbody work again
                                                                                  //noahbiteobject.GetComponent<Rigidbody>().useGravity = true;
                    noahbiteobject.transform.parent = null; // make the object no be a child of the hands           
                    noahbiteobject.transform.position = new Vector3(NoahPosition.gameObject.transform.position.x, 33.799f, NoahPosition.gameObject.transform.position.z);

                    noahbiteobject.transform.rotation = Quaternion.Euler(0, NoahPosition.gameObject.transform.rotation.y, 0);
                    BiteDestroyButton.bitedestroybutton.ISBITE = false;
                }
            }
        }
    }
}
