using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance { get; private set; }
    // 다른 스크립트들이 Inventory 의 값은 가져올 수 있지만, 값을 변경할 수 없음
    public Inventory Inventory { get { return Inventory; } }

    [SerializeField] Inventory inventory;

    /* 싱글톤 구현 */
    // 데이터 매니저 자신과, 이 클래스를 가지고 있는 오브젝트들 
    private void Awake() // 다른 스크립트들이 실행되기 전에 초기화
    {
        if(Instance == null) // 아무도 Instance 키워드를 사용하지 않았으면
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // 만약에 씬1과 씬2 둘다 데이터 매니저가 존재한다면, 씬2로 이동할 때 씬1의 데이터매니저를 삭제시킴
            Destroy(gameObject); 

        }
    }
}
