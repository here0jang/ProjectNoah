using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

// 상속?? SomeClass 안에 있는    변수들 중 필요한 것만 모아서 원하는 인스펙터 만들기?
[CustomEditor(typeof(SomeClass))]
public class SomeClassEditor : Editor
{
    SomeClass source;
    // serializeField 변수들을 가지고 커스텀 인스펙터 만들기
    SerializedProperty playerName, speed, playerPosition, playerPrefabs;

    private void OnEnable()
    {
        // source 는 type of subclass, target 은 object 이기 때문에 
        // cast object to someclass 
        // or add a typecasting 
        source = (SomeClass)target; // target : object being inspected
        playerName = serializedObject.FindProperty("s_playerName");
        speed = serializedObject.FindProperty("s_speed");
        playerPosition = serializedObject.FindProperty("s_playerPosition");
        playerPrefabs = serializedObject.FindProperty("s_playerPrefabs");
    }
    public override void OnInspectorGUI()
    {
        //base.OnInspectorGUI(); 
        GUILayout.BeginVertical("box"); // 인스펙터의 변수들을 박스로 그룹지어줌
        source.playerName = EditorGUILayout.TextField("Player Name : ", source.playerName);
        source.speed = EditorGUILayout.FloatField("speed : ", source.speed);
        source.playerPosition = EditorGUILayout.Vector3Field("playerPosition : ", source.playerPosition);
        // GameObject 로 casting 해줌, true 이면 씬 안의 오브젝트도 끌어올 수 있음
        source.playerPrefabs = (GameObject)EditorGUILayout.ObjectField(source.playerPrefabs, typeof(GameObject), true);
        GUILayout.EndVertical();

        GUILayout.BeginVertical("box");
        EditorGUILayout.PropertyField(playerName, new GUIContent("Player Name: "));
        EditorGUILayout.PropertyField(speed, new GUIContent("Player Speed: "));
        EditorGUILayout.PropertyField(playerPosition, new GUIContent("Player Position: "));
        EditorGUILayout.PropertyField(playerPrefabs, new GUIContent("Player Prefabs: "));
        GUILayout.EndVertical();

        // 인스펙터에 버튼도 만들 수 있음
        if (GUILayout.Button("Randomize Speed"))
        {
            source.speed = Random.Range(5f, 25f);
            //speed.floatValue = Random.Range(5f, 25f); // serializedProperty 의 speed 변수 바꾸기
        }

        // SerializedProperty 를 쓰면 아래 문장을 써야 인스펙터 상에 변화가 생겨도 안전함
        serializedObject.ApplyModifiedProperties();
    }
}
