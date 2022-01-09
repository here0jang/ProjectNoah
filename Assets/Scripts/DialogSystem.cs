using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogSystem : MonoBehaviour
{
   // get set 나중에 찾아보기
    public static DialogSystem Instance { get; private set; }

    [SerializeField] TMPro.TextMeshProUGUI messageText, yesText, noText;
    [SerializeField] GameObject panel;
    [SerializeField] Button yesButton, noButton;

    private List<string> currentMessages = new List<string>();
    private int msgID = 0;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        panel.SetActive(false);
    }

    public void ShowMessages(List<string> messages, bool dialog, List<Actions> yesActions = null, List<Actions> noActions = null, string yes = "Yes", string no = "No" )
    {
        msgID = 0;
        yesButton.transform.parent.gameObject.SetActive(false);

        currentMessages = messages;
        panel.SetActive(true);
        // 코루틴 시작 전에 버튼에 값 할당
        if(dialog)
        {
            yesText.text = yes;
            // 액션 전달, 버튼에 메서드 전달
            yesButton.onClick.RemoveAllListeners(); // 이전에 있었던 메서드 삭제
            yesButton.onClick.AddListener(delegate
            {
                panel.SetActive(false);

                if (yesActions !=null)
                {
                    AssignActionstoButtons(yesActions);
                }
            }); /* delegate ?? */

            noText.text = no;
            noButton.onClick.RemoveAllListeners(); // 이전에 있었던 메서드 삭제
            noButton.onClick.AddListener(delegate
            {
                panel.SetActive(false);
                if (noActions!=null)
                {
                    AssignActionstoButtons(noActions);
                }           
            }); 

        }
        StartCoroutine(ShowMultipleMessages(dialog));
    }

    IEnumerator ShowMultipleMessages(bool useDialog)
    {
        messageText.text = currentMessages[msgID];
        while(msgID < currentMessages.Count)
        {
            if(Input.GetKeyDown(KeyCode.Space)||(Input.GetMouseButtonDown(0)&&Extensions.IsMouseOverUI()))
            {
                msgID++;

                if(msgID<currentMessages.Count)
                {
                    messageText.text = currentMessages[msgID];
                }

                // 마지막 메시지일 때 예 아니오 버튼도 나타나게 하기
                if(msgID < currentMessages.Count)
                {
                    messageText.text = currentMessages[msgID];
                }
                if(useDialog && msgID == currentMessages.Count - 1)
                {
                    yesButton.transform.parent.gameObject.SetActive(true);
                }
            }
            yield return null;
        }

        if(!useDialog)
            panel.SetActive(false);
    }

    void AssignActionstoButtons(List<Actions> actions)
    {
        List<Actions> localActions = actions;

        for(int i = 0;  i<localActions.Count;  i++)
        {
            localActions[i].Act();
        }
    }

    // dialog system 을 쓰고 있을 때 버튼을 클릭하면 패널이 사라지게 할 것 
    // 새로운 메시지를 볼 때마다 

    // 상호작용 도중에 갑자기 멈추면 메시지가 사라지게
    public void HideDialog()
    {
        panel.SetActive(false);
    }
}
