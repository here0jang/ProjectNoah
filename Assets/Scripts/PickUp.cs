using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public Transform theDest;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P)) // Long Button - bite ´©¸£¸é
        {
            GetComponent<Rigidbody>().useGravity = false;
            this.transform.position = theDest.position;
            this.transform.parent = GameObject.Find("BitePosition").transform;
            GetComponent<BoxCollider>().enabled = false;

        }

        if(Input.GetMouseButtonDown(1))
        {
            this.transform.parent = null;
            GetComponent<Rigidbody>().useGravity = true;
            GetComponent<BoxCollider>().enabled = true;
        }
        
    }
}
