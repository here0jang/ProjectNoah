using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cam : MonoBehaviour
{
    public static cam newCam { get; private set; }
    
    public Camera mainCamera;

    public Transform Mainview;

    private Transform camObserveView;
    // public float transitionSpeed;
    // public Transform currentVieww;
    [SerializeField] GameObject noah;

    private void Awake()
    {
        newCam = this;
    }

    public void ObserveButtonClick()
    {
        camObserveView = PlayerScripts.playerscripts.PlayerobserveView;
        changeView(camObserveView);
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
        /* �����ϱ� ��Ȱ��ȭ 
        if(Input.GetKeyDown("space"))
        {
            // currentVieww = views[1];
            changeView(views[1]);
        }    
        */

        if (Input.GetMouseButtonDown(1))
        {
            changeView(Mainview);
            noah.transform.gameObject.SetActive(true);
        }
    }
    
    /* ��ȯ ȿ�� ���� ī�޶� ��ȯ �޼��� */
    void changeView(Transform view)
    {
        mainCamera.transform.position = view.position;
        mainCamera.transform.rotation = view.rotation;
    }

    /* ��ȯ ȿ�� �ִ� ī�޶� ��ȯ 
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