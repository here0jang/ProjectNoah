using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

// 정적 클래스
// 정적 변수와 메서드만 가질 수 있음
// 클래스로부터 객체를 생성하지 않고 변수나 함수를 호출할 수 있음
public static class Extensions
{
    public static bool IsMouseOverUI()
    { // 마우스가 UI 위에 있으면 참
        return EventSystem.current.IsPointerOverGameObject();
    }
}
