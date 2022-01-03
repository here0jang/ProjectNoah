using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageAction : Actions
{
    [Multiline(5)]
    [SerializeField] List<string> messages;
    public override void Act()
    {
        DialogSystem.Instance.ShowMessage(messages);
    }
}
