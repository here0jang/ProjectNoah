using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageAction : Actions
{
    [Multiline(5)]
    [SerializeField] List<string> messages;
    [SerializeField] bool enableDialog;
    [SerializeField] List<Actions> yesActions, noActions;
    public override void Act()
    {
        DialogSystem.Instance.ShowMessages(messages);
    }
}

// 예 / 아니오 선택 -> 리액션 나오게
