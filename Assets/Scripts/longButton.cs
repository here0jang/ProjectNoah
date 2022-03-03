using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class longButton : MonoBehaviour
{
    public static longButton longbutton { get; private set; }

    public Animator PlayerAnim;
    public Button barkButton, pushButton, pressButton, sniffButton, biteButton, upDownButton, insertButton, updownDisableedButton, noCenterButton;

    private bool isobjectobserve;
    public Button observeButton;

    [SerializeField] GameObject Noah;
    [SerializeField] GameObject NoahPlayer;
    public GameObject noahpushObject;
    public static GameObject noahpushobject;
    public static bool ISPUSH = false;
    public bool ispush = false;

    public static string pushObjectName;

    public bool IsBark = false;

    public bool isGrounded = true;
    public Rigidbody rigidbodybody;
    public NavMeshAgent Playeragent;
    private Vector3 risePosition;
    public GameObject InsertArea;

    public GameObject DoorLocked;
    public GameObject DoorUnLocked;

    void Awake()
    {
        longbutton = this;
        PlayerAnim.SetBool("IsSleeping", true);
        barkButton.onClick.AddListener(playerBark);
        sniffButton.onClick.AddListener(playerSniff);
        observeButton.onClick.AddListener(playerObserve);
        upDownButton.onClick.AddListener(playerRising);
        insertButton.onClick.AddListener(playerInserting);
        pushButton.onClick.AddListener(playerPush);
        pressButton.onClick.AddListener(playerPress);
    }

    void Start()
    {
        if (SceneManager.GetActiveScene().name == "Cockpit")
            StartCoroutine(NoahWakeUp());
        else
            StartCoroutine(NoahWalking());

    }

    IEnumerator NoahWakeUp()
    {
        yield return new WaitForSeconds(2f);
        PlayerAnim.SetBool("IsWaking", true);
        yield return new WaitForSeconds(1f);
        PlayerAnim.SetBool("IsWaking2", true);
        yield return new WaitForSeconds(1f);
        PlayerAnim.SetBool("IsSleeping", false);
    }

    IEnumerator NoahWalking()
    {
        yield return new WaitForSeconds(0.0001f);
        PlayerAnim.SetBool("IsWaking", true);
        PlayerAnim.SetBool("IsWaking2", true);
        PlayerAnim.SetBool("IsSleeping", false);
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

    public void TurnOffInteractionButton()
    {
        barkButton.transform.gameObject.SetActive(false);
        pushButton.transform.gameObject.SetActive(false);
        pressButton.transform.gameObject.SetActive(false);
        noCenterButton.transform.gameObject.SetActive(false);
        updownDisableedButton.transform.gameObject.SetActive(false);
        upDownButton.transform.gameObject.SetActive(false);
        insertButton.transform.gameObject.SetActive(false);
        observeButton.transform.gameObject.SetActive(false);
        sniffButton.transform.gameObject.SetActive(false);
        biteButton.transform.gameObject.SetActive(false);
    }

    //&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&

    void playerBark()
    {
        PlayerManager.playermanager.isBark = true;
        TurnOffInteractionButton();
        Invoke("ChangeBarkTrue", 0.5f);
        Invoke("ChangeBarkFalse", 2);
    }

    void ChangeBarkTrue()
    {
        PlayerAnim.SetBool("IsBarking", true);
    }

    void ChangeBarkFalse()
    {
        PlayerAnim.SetBool("IsBarking", false);
    }
    /* 오브젝트에 짖었을 때 그에 맞는 반응 필요 */

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
        PlayerAnim.SetBool("IsSniffing", true);
    }

    void ChangeSniffFalse()
    {
        PlayerAnim.SetBool("IsSniffing", false);
    }

    void TurnOnTheSmellPanel()
    {
        DialogSystem.Instance.Smell();
        DoorController.doorController.isDoorOpen = false;
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
        PlayerAnim.SetBool("IsObserving", true);
    }

    void ChangeObserveFalse()
    {
        PlayerAnim.SetBool("IsObserving", false);
    }

    void ChangeCameraView()
    {
        cam.newCam.ObserveButtonClick();
        Noah.transform.gameObject.SetActive(false);
        //isobjectobserve = PlayerScripts.playerscripts.ObjectIsObserve;
    }

    //&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
    void playerRising()
    {
        noahpushObject = PlayerScripts.playerscripts.PlayerNoahPushObject;
        risePosition = noahpushObject.transform.localPosition;
        TurnOffInteractionButton();
        if (isGrounded)
        {
            isGrounded = false;
            if (Playeragent.enabled)
            {
                // set the agents target to where you are before the jump
                // this stops her before she jumps. Alternatively, you could
                // cache this value, and set it again once the jump is complete
                // to continue the original move
                //Playeragent.SetDestination(transform.position);
                // disable the agent
                Playeragent.updatePosition = false;
                Playeragent.updateRotation = false;
                Playeragent.isStopped = true;
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

            Playeragent.isStopped = false;
        }
    }

    void ChangeRiseTrue()
    {
        PlayerAnim.SetBool("IsRising", true);

    }
    void ChangeRise2True()
    {
        PlayerAnim.SetBool("IsRising2", true);
    }
    void ChangeRise3True()
    {
        PlayerAnim.SetBool("IsRising3", true);
    }
    void ChangeRise4True()
    {
        PlayerAnim.SetBool("IsRising4", true);
    }
    void ChangeRise5True()
    {
        PlayerAnim.SetBool("IsRising5", true);
    }


    void ChangeRiseFalse()
    {
        PlayerAnim.SetBool("IsRising", false);
    }
    void noahJump()
    {
        NoahPlayer.transform.position = new Vector3(risePosition.x, 35.3f, risePosition.z + 0.4f);
    }

    //&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&

    void playerPush()
    {
        noahpushObject = PlayerScripts.playerscripts.PlayerNoahPushObject;
        noahpushobject = noahpushObject;
        pushObjectName = noahpushObject.name;
        //PlayerManager.playermanager.ISPUSH = true;
        ispush = true;
        ISPUSH = true;
        TurnOffInteractionButton();
        Invoke("ChangePushTrue", 0.5f);
        noahpushObject.transform.parent = Noah.transform;
    }

    void ChangePushTrue()
    {
        PlayerAnim.SetBool("IsPushing", true);
    }

    //&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&

    void playerPress()
    {
        noahpushObject = PlayerScripts.playerscripts.PlayerNoahPushObject;
        TurnOffInteractionButton();
        // 탑뷰로 전환한다. 
        cam.newCam.CancelObserve();
        // 노아 누르는 애니메이션 보여준다. 
        Invoke("ChangePressTrue", 0.5f);
        Invoke("ChangePressFalse", 2f);
        if (noahpushObject.name == "Console_Left_ResetButton")
        {
            DialogManager.dialogManager.ResetSystem();
        }
        if (noahpushObject.name == "Console_Left_UnLockButton")
        {
            // 문이 열렸다 닫힌다
            DoorController.doorController.isDoorOpen = true;
            //Invoke("IsDoorOpenTrue", 2.5f);
            Invoke("IsDoorOpenFalse", 1f);
        }
    }
    void ChangePressTrue()
    {
        PlayerAnim.SetBool("IsPressing", true);
    }
    void ChangePressFalse()
    {
        PlayerAnim.SetBool("IsPressing", false);
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
        InsertArea.SetActive(true);
        if (isGrounded)
        {
            isGrounded = false;
            if (Playeragent.enabled)
            {
                // set the agents target to where you are before the jump
                // this stops her before she jumps. Alternatively, you could
                // cache this value, and set it again once the jump is complete
                // to continue the original move
                //Playeragent.SetDestination(transform.position);
                // disable the agent
                Playeragent.updatePosition = false;
                Playeragent.updateRotation = false;
                Playeragent.isStopped = true;
            }
        }

        NoahPlayer.transform.position = new Vector3(22.3f, 34.03531f, -1.002877f);
        NoahPlayer.transform.Rotate(0, -90, 0);
        Playeragent.isStopped = false;
        DoorLocked.SetActive(false);
        DoorUnLocked.SetActive(true);
    }

    void ChangeInsertTrue()
    {
        PlayerAnim.SetBool("IsInserting", true);
    }

    public void ChangeInsertfalse()
    {
        PlayerAnim.SetBool("IsInserting", false);
    }

    public void TurnOffInsertArea()
    {
        InsertArea.SetActive(false);
    }
}
