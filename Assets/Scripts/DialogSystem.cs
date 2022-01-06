using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogSystem : MonoBehaviour
{
   // get set 나중에 찾아보기
    public static DialogSystem Instance { get; private set; }

    [SerializeField] TMPro.TextMeshProUGUI messageText;
    [SerializeField] GameObject panel;

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

    public void ShowMessages(List<string> messages, bool dialog, List<Actions> yesActions, List<Actions> noActions)
    {
        currentMessages = messages;
        panel.SetActive(true);
        StartCoroutine(ShowMultipleMessages());
    }

    IEnumerator ShowMultipleMessages()
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
            }
            yield return null;
        }
        panel.SetActive(false);
        msgID = 0;

    }



}
