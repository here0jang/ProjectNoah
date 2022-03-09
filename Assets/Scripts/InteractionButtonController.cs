using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class InteractionButtonController : MonoBehaviour
{
    public static InteractionButtonController interactionButtonController { get; private set; }

    public Animator noahAnim;
    public Button barkButton, pushButton, pressButton, sniffButton, biteButton, upDownButton, insertButton, noCenterButton, observeButton;
    [SerializeField] GameObject noah, noahPlayer;

    public bool isObserve = false;
    public bool isBark = false;

    public bool isGround = true;
    public Rigidbody playerRigidbody;
    public NavMeshAgent playerAgent;
    private Vector3 risePosition;
    public GameObject noahClimbObject;



    public GameObject goToWork;
    public GameObject noahPushObject;
    public static GameObject noahpushobject;
    public static bool ISPUSH = false;
    public bool ispush = false;
    public static string pushObjectName;

    public GameObject InsertArea, DoorLocked, DoorUnLocked;

    void Start()
    {
        if (SceneManager.GetActiveScene().name == "new cockpit")
            StartCoroutine(NoahWakeUp());
        else
            StartCoroutine(NoahWalking());
    }

    void Awake()
    {
        interactionButtonController = this;

        noahAnim.SetBool("IsSleeping", true);

        barkButton.onClick.AddListener(playerBark);
        sniffButton.onClick.AddListener(playerSniff);
        observeButton.onClick.AddListener(playerObserve);
        upDownButton.onClick.AddListener(playerRising);
        insertButton.onClick.AddListener(playerInserting);
        pushButton.onClick.AddListener(playerPush);
        pressButton.onClick.AddListener(playerPress);
    }

    IEnumerator NoahWakeUp()
    {
        yield return new WaitForSeconds(2f);
        noahAnim.SetBool("IsWaking", true);
        yield return new WaitForSeconds(1f);
        noahAnim.SetBool("IsWaking2", true);
        yield return new WaitForSeconds(1f);
        noahAnim.SetBool("IsSleeping", false);
    }

    IEnumerator NoahWalking()
    {
        yield return new WaitForSeconds(0.0001f);
        noahAnim.SetBool("IsWaking", true);
        noahAnim.SetBool("IsWaking2", true);
        noahAnim.SetBool("IsSleeping", false);
    }

    private void Update()
    {
        if (ispush == false)
        {
            ISPUSH = false;
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log("ispush : " + ISPUSH);
            Debug.Log(pushObjectName);
        }
    }

    //&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
    void playerRising()
    {
        noahClimbObject = PlayerScripts.playerscripts.PlayerNoahClimbObject;
        risePosition = noahClimbObject.transform.localPosition;
        TurnOffInteractionButton();
        if (isGround)
        {
            isGround = false;
            if (playerAgent.enabled)
            {
                // set the agents target to where you are before the jump
                // this stops her before she jumps. Alternatively, you could
                // cache this value, and set it again once the jump is complete
                // to continue the original move
                //Playeragent.SetDestination(transform.position);
                // disable the agent
                playerAgent.updatePosition = false;
                playerAgent.updateRotation = false;
                playerAgent.isStopped = true;
            }
            Invoke("ChangeRiseTrue", 0.5f);
            Invoke("ChangeRise2True", 0.5f);
            Invoke("ChangeRise3True", 0.5f);
            Invoke("ChangeRise4True", 0.5f);
            Invoke("ChangeRise5True", 0.5f);
            Invoke("noahJump", 1f);
            // make the jump
            //rigidbodybody.isKinematic = false;
            //rigidbodybody.useGravity = true;
            //rigidbodybody.AddRelativeForce(new Vector3(0, 5f, 0), ForceMode.Impulse);
            Invoke("ChangeRiseFalse", 2);

            playerAgent.isStopped = false;
        }
    }

    void ChangeRiseTrue()
    {
        noahAnim.SetBool("IsRising", true);

    }
    void ChangeRise2True()
    {
        noahAnim.SetBool("IsRising2", true);
    }
    void ChangeRise3True()
    {
        noahAnim.SetBool("IsRising3", true);
    }
    void ChangeRise4True()
    {
        noahAnim.SetBool("IsRising4", true);
    }
    void ChangeRise5True()
    {
        noahAnim.SetBool("IsRising5", true);
    }


    void ChangeRiseFalse()
    {
        noahAnim.SetBool("IsRising", false);
    }
    void noahJump()
    {
        noahPlayer.transform.position = new Vector3(risePosition.x, 34.69f, risePosition.z + 0.4f);
    }

    //&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&

    void playerPush()
    {
        noahPushObject = PlayerScripts.playerscripts.PlayerNoahPushObject;
        noahpushobject = noahPushObject;
        pushObjectName = noahPushObject.name;
        //PlayerManager.playermanager.ISPUSH = true;
        ispush = true;
        ISPUSH = true;
        TurnOffInteractionButton();
        Invoke("ChangePushTrue", 0.5f);
        noahPushObject.transform.parent = noah.transform;
    }

    void ChangePushTrue()
    {
        noahAnim.SetBool("IsPushing", true);
    }

    //&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&

    void playerPress()
    {
        noahPushObject = PlayerScripts.playerscripts.PlayerNoahPushObject;
        TurnOffInteractionButton();
        // ž��� ��ȯ�Ѵ�. 
        CameraController.cameraController.CancelObserve();
        // ��� ������ �ִϸ��̼� �����ش�. 
        Invoke("ChangePressTrue", 0.5f);
        Invoke("ChangePressFalse", 2f);
        if (noahPushObject.name == "Console_Left_ResetButton")
        {
            DialogManager.dialogManager.ResetSystem();
        }
        if (noahPushObject.name == "Console_Left_UnLockButton")
        {
            // ���� ���ȴ� ������
            DoorController.doorController.isDoorOpen = true;
            //Invoke("IsDoorOpenTrue", 2.5f);
            Invoke("IsDoorOpenFalse", 1f);
        }
    }
    void ChangePressTrue()
    {
        noahAnim.SetBool("IsPressing", true);
    }
    void ChangePressFalse()
    {
        noahAnim.SetBool("IsPressing", false);
    }
    void IsDoorOpentTrue()
    {
        DoorController.doorController.isDoorOpen = true;
    }
    void IsDoorOpenFalse()
    {
        DoorController.doorController.isDoorOpen = false;
    }

    //&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&

    void playerInserting()
    {
        TurnOffInteractionButton();
        Invoke("ChangeInsertTrue", 0.5f);
        //InsertArea.SetActive(true);
        if (isGround)
        {
            isGround = false;
            if (playerAgent.enabled)
            {
                // set the agents target to where you are before the jump
                // this stops her before she jumps. Alternatively, you could
                // cache this value, and set it again once the jump is complete
                // to continue the original move
                //Playeragent.SetDestination(transform.position);
                // disable the agent
                playerAgent.updatePosition = false;
                playerAgent.updateRotation = false;
                playerAgent.isStopped = true;
            }
        }

        noahPlayer.transform.position = new Vector3(21.5f, 34.03531f, -1.002877f);
        noahPlayer.transform.rotation = Quaternion.Euler(0, 0, 0);
        //NoahPlayer.transform.Rotate(0, 0, 0);
        //Playeragent.isStopped = false;
        DoorController.doorController.isDoorOpen = true;
        isGround = true;
        Invoke("ChangeInsertFalse", 0.05f);
        goToWork.SetActive(true);
        if (playerAgent.enabled)
        {
            playerAgent.updatePosition = true;
            playerAgent.updateRotation = true;
            playerAgent.isStopped = false;
        }




        //DoorLocked.SetActive(false);
        //DoorUnLocked.SetActive(true);
    }

    void ChangeInsertTrue()
    {
        noahAnim.SetBool("IsInserting", true);
    }

    public void ChangeInsertfalse()
    {
        noahAnim.SetBool("IsInserting", false);
    }

    public void TurnOffInsertArea()
    {
        InsertArea.SetActive(false);
    }

    //&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&

    public void TurnOffInteractionButton()
    {
        barkButton.transform.gameObject.SetActive(false);
        pushButton.transform.gameObject.SetActive(false);
        pressButton.transform.gameObject.SetActive(false);
        noCenterButton.transform.gameObject.SetActive(false);
        upDownButton.transform.gameObject.SetActive(false);
        insertButton.transform.gameObject.SetActive(false);
        observeButton.transform.gameObject.SetActive(false);
        sniffButton.transform.gameObject.SetActive(false);
        biteButton.transform.gameObject.SetActive(false);
    }

    //&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&   

    void playerBark()
    {
        GameManager.gameManager.isBark = true;
        TurnOffInteractionButton();
        Invoke("ChangeBarkTrue", 0.5f);
        Invoke("ChangeBarkFalse", 2);
    }

    void ChangeBarkTrue()
    {
        noahAnim.SetBool("IsBarking", true);
    }

    void ChangeBarkFalse()
    {
        noahAnim.SetBool("IsBarking", false);
    }

    //&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&

    void playerSniff()
    {
        TurnOffInteractionButton();
        Invoke("ChangeSniffTrue", 0.5f);
        Invoke("ChangeSniffFalse", 2);
        Invoke("TurnOnTheSmellPanel", 2);
    }

    void ChangeSniffTrue()
    {
        noahAnim.SetBool("IsSniffing", true);
    }

    void ChangeSniffFalse()
    {
        noahAnim.SetBool("IsSniffing", false);
    }

    void TurnOnTheSmellPanel()
    {
        DialogSystem.Instance.Smell();
    }

    //&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&

    void playerObserve()
    {
        TurnOffInteractionButton();
        Invoke("ChangeObserveTrue", 0.5f);
        Invoke("ChangeObserveFalse", 2);
        Invoke("ChangeCameraView", 2);
    }

    void ChangeObserveTrue()
    {
        noahAnim.SetBool("IsObserving", true);
    }

    void ChangeObserveFalse()
    {
        noahAnim.SetBool("IsObserving", false);
    }

    void ChangeCameraView()
    {
        CameraController.cameraController.ObserveButtonClick();
        noah.transform.gameObject.SetActive(false);
        isObserve = true;
    }
}
