using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cam : MonoBehaviour
{
    public static cam newCam { get; private set; }
    
    public Camera mainCamera;

    private Transform camObserveView, camObserveboxView;
    public Transform MainView;
    public GameObject CockpitButtonDescription;
    // public float transitionSpeed;
    // public Transform currentVieww;
    [SerializeField] GameObject noah;

    public GameObject AIPanels, UIs;

    private void Awake()
    {
        newCam = this;     
    }

    public void ObserveButtonClick()
    {
        camObserveView = PlayerScripts.playerscripts.PlayerobserveView;
        camObserveboxView = PlayerScripts.playerscripts.PlayerobserveBoxView;
        //gameObject.GetComponent<SceneCameraControl>().enabled = false;
        AIPanels.SetActive(false);
        UIs.SetActive(false);
        if (longButton.longbutton.isGrounded == true)
        {
            changeView(camObserveView);
        }
        else
        {
            changeView(camObserveboxView);
            CockpitButtonDescription.SetActive(true);
        }
    }

    public void CancelObserve()
    {
        AIPanels.SetActive(true);
        UIs.SetActive(true);
        changeView(MainView);
        noah.transform.gameObject.SetActive(true);
        CockpitButtonDescription.SetActive(false);
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


        //if (Input.GetMouseButtonDown(1))
        //{
        //    //gameObject.GetComponent<SceneCameraControl>().enabled = true;

        //}
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
