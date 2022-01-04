using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public static class Extensions
{
    public static bool IsMouseOverUI()
    { // 마우스가 UI 위에 있으면 참
        return EventSystem.current.IsPointerOverGameObject();
    }
}
