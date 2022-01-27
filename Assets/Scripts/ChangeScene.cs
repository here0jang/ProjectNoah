using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    [SerializeField] string transferMapName;

    public void changePlayerScene()
    {
        SceneManager.LoadScene(transferMapName);
    }
}
