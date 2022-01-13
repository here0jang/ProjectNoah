using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class cam : MonoBehaviour
{
    public Camera mainCamera;
    public Button ObserveButton, BarkButton, PushButton, SniffButton, UpButton;
    public Transform[] views;
    // public float transitionSpeed;
    // public Transform currentVieww;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ObserveButtonClick()
    {
        changeView(views[0]);

        ObserveButton.transform.gameObject.SetActive(false);
        BarkButton.transform.gameObject.SetActive(false);
        PushButton.transform.gameObject.SetActive(false);
        SniffButton.transform.gameObject.SetActive(false);
        UpButton.transform.gameObject.SetActive(false);

    }

    void Update()
    {
        /*
        if(Input.GetButtonDown("Observe"))
        {
            changeView(views[0]);
        }
        
        if(Input.GetKeyDown("space"))
        {
            //currentVieww = views[0];
            changeView(views[0]);
        }
        /* 관찰하기 비활성화 
        if(Input.GetKeyDown("space"))
        {
            // currentVieww = views[1];
            changeView(views[1]);
        }    
        */
    }
    
    /* 전환 효과 없는 카메라 전환 메서드 */
    void changeView(Transform view)
    {
        mainCamera.transform.position = view.position;
        mainCamera.transform.rotation = view.rotation;
    }

    /* 전환 효과 있는 카메라 전환 
    void LateUpdate()
    {
        transform.position = 

        transform.position = Vector3.Lerp(transform.position, currentVieww.position, Time.deltaTime*transitionSpeed);

        Vector3 currentAngle = new Vector3(
            Mathf.LerpAngle(transform.rotation.eulerAngles.x, currentVieww.transform.rotation.eulerAngles.x, Time.deltaTime*transitionSpeed),
            Mathf.LerpAngle(transform.rotation.eulerAngles.y, currentVieww.transform.rotation.eulerAngles.y, Time.deltaTime*transitionSpeed),
            Mathf.LerpAngle(transform.rotation.eulerAngles.z, currentVieww.transform.rotation.eulerAngles.z, Time.deltaTime*transitionSpeed));

        transform.eulerAngles = currentAngle;
    } */


}
