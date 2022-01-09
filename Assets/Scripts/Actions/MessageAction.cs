using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// NPC 에게 붙는 스크립트
public class MessageAction : Actions
{
    [Multiline(5)]

    [SerializeField] List<string> messages;
    [SerializeField] bool enableDialog;
    [SerializeField] string yesText, noText;
    [SerializeField] List<Actions> yesActions, noActions;
    public override void Act() // Actions 추상 클래스를 상속받았기 때문에 반드시 Act() 메서드를 가지고 있어야 한다. 
    {
        // 메세지 출력함
        DialogSystem.Instance.ShowMessages(messages, enableDialog, yesActions, noActions, yesText, noText);
    }
}

// 예 / 아니오 선택 -> 리액션 나오게
