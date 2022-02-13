using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaintainInteractableObject : MonoBehaviour
{
    public GameObject noahposition;
    public GameObject mymouth;
    public Animator playeranimation;

    private GameObject noahpushobject;

    // Update is called once per frame
    void Update()
    {
        if (longButton.longbutton.ispush)
        {
            noahpushobject = longButton.longbutton.noahpushObject;
            if (noahpushobject != null)
            {
                PlayerManager.playermanager.isPush = true;
                playeranimation.SetBool("IsPushing", true);
                noahpushobject.GetComponent<Rigidbody>().isKinematic = true;   //makes the rigidbody not be acted upon by forces
                noahpushobject.GetComponent<Rigidbody>().useGravity = false;
                noahpushobject.transform.position = mymouth.transform.position; // sets the position of the object to your hand position
                noahpushobject.transform.parent = mymouth.transform; //makes the object become a child of the parent so that it moves with the hands
            }
        }
    }
}
