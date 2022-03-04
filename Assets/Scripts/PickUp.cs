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

    private void Start() // �÷��̾� �������� �÷��̾� �Կ� ������ ���� ���·� ����
    {
        playerPipe.GetComponent<Rigidbody>().useGravity = false;
        playerPipe.transform.position = theDest.position;
        playerPipe.transform.parent = GameObject.Find("BitePosition").transform;
        playerPipe.GetComponent<BoxCollider>().enabled = false;

        playerPipe.transform.gameObject.SetActive(false);
    }

    void Update()
    {
        if(isBiting == true) // �ι� ������ ������ ���¿��� bite ������ -> �÷��̾� ������ Ȱ��ȭ, �ι� ������ ����
        {
            playerPipe.transform.gameObject.SetActive(true);
            Destroy(environmentPipe);
            isBiting = false;
        }

        //if(Input.GetKeyDown(KeyCode.P)) // Long Button - bite ������
        //{
        //    isBiting = true;
        //    GetComponent<Rigidbody>().useGravity = false;
        //    this.transform.position = theDest.position;
        //    this.transform.parent = GameObject.Find("BitePosition").transform;
        //    GetComponent<BoxCollider>().enabled = false;

        //}

        //if(Input.GetMouseButtonDown(1)) // ���� �÷��̾� ��ġ �ٴڿ� �ι������� ����, �÷��̾� ������ ��Ȱ��ȭ
        //{
        //    playerPipe.transform.gameObject.SetActive(false);
        //    isBiting = false;
        //    this.transform.parent = null;
        //    GetComponent<Rigidbody>().useGravity = true;
        //    GetComponent<BoxCollider>().enabled = true;
        //}
        
    }
}
 