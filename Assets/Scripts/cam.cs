using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cam : MonoBehaviour
{
    public Transform[] views;
    public float transitionSpeed;
    public Transform currentVieww;




    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetKeyDown("space"))
        {
            
            currentVieww = views[1];

        }
        /*
        if(Input.GetMouseButtonDown(0))
        {
            
            currentVieww = views[1];

        }
        if(Input.GetMouseButtonDown(1))
        {
            currentVieww = views[0];

        }
        */
        
    }
    void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, currentVieww.position, Time.deltaTime*transitionSpeed);
        
        Vector3 currentAngle = new Vector3(
            Mathf.LerpAngle(transform.rotation.eulerAngles.x, currentVieww.transform.rotation.eulerAngles.x, Time.deltaTime*transitionSpeed),
            Mathf.LerpAngle(transform.rotation.eulerAngles.y, currentVieww.transform.rotation.eulerAngles.y, Time.deltaTime*transitionSpeed),
            Mathf.LerpAngle(transform.rotation.eulerAngles.z, currentVieww.transform.rotation.eulerAngles.z, Time.deltaTime*transitionSpeed));
        
        transform.eulerAngles = currentAngle;
  
    }
}
