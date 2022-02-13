using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager playermanager { get; private set; }

    public static int Hp = 100;
    public bool isBark = false;

    public static GameObject currentObject;
    public static bool isPushing = false;
    public bool isPush = false;

    public GameObject noahThePlayer;

    private void Awake()
    {
        playermanager = this;
    }

    private void Update()
    {
        if(isBark == true) // Â¢À¸¸é
        {
            Hp -= 10;
            isBark = false;
        }


        //if (Input.GetKeyDown(KeyCode.Q))
        //{
        //    Debug.Log("Ã¼·Â: " + Hp);
        //    Debug.Log(isPushing);
        //    //Debug.Log(currentObject);
        //}

        isPushing = isPush;

        if(isPushing == true)
        {
            currentObject = PlayerScripts.playerscripts.CurrentObject;
            currentObject.transform.parent = noahThePlayer.transform;
        }
    }
}
