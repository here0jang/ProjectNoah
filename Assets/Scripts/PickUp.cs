using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public static PickUp pickup { get; private set; }
    public Transform theDest;
    public GameObject environmentPipe;
    public GameObject playerPipe;
    public bool isBiting = false;
    private void Awake()
    {
        pickup = this;
    }

    private void Start() // 플레이어 파이프는 플레이어 입에 있으나 꺼진 상태로 시작
    {
        playerPipe.GetComponent<Rigidbody>().useGravity = false;
        playerPipe.transform.position = theDest.position;
        playerPipe.transform.parent = GameObject.Find("BitePosition").transform;
        playerPipe.GetComponent<BoxCollider>().enabled = false;

        playerPipe.transform.gameObject.SetActive(false);
    }

    void Update()
    {
        if(isBiting == true) // 인바 파이프 선택한 상태에서 bite 누르면 -> 플레이어 파이프 활성화, 인바 파이프 삭제
        {
            playerPipe.transform.gameObject.SetActive(true);
            Destroy(environmentPipe);
            isBiting = false;
        }

        //if(Input.GetKeyDown(KeyCode.P)) // Long Button - bite 누르면
        //{
        //    isBiting = true;
        //    GetComponent<Rigidbody>().useGravity = false;
        //    this.transform.position = theDest.position;
        //    this.transform.parent = GameObject.Find("BitePosition").transform;
        //    GetComponent<BoxCollider>().enabled = false;

        //}

        //if(Input.GetMouseButtonDown(1)) // 현재 플레이어 위치 바닥에 인바파이프 생성, 플레이어 파이프 비활성화
        //{
        //    playerPipe.transform.gameObject.SetActive(false);
        //    isBiting = false;
        //    this.transform.parent = null;
        //    GetComponent<Rigidbody>().useGravity = true;
        //    GetComponent<BoxCollider>().enabled = true;
        //}
        
    }
}
 