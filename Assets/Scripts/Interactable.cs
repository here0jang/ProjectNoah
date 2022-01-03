using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    [SerializeField] Actions[] actionss;

    [SerializeField] float distancePosition = 1f;

    public Vector3 InteractPosition()
    {
        return transform.position + transform.forward*distancePosition;
    }
    public void Interact(PlayerScripts player)
    {
        Debug.Log(gameObject.name+"Clicked by the player");

        StartCoroutine(WaitforPlayerArriving(player));
    }

    IEnumerator WaitforPlayerArriving(PlayerScripts player)
    {
        // 플레이어가 도착하지 않았으면 코루틴을 딜레이함
        while(!player.CheckIfArrived())
        {
            yield return null;
        }
        // it will the code below when the player arrives
        Debug.Log("Player arrived");
        player.SetDirection(transform.position);

        for(int i=0; i<actionss.Length; i++)
        {
            actionss[i].Act();
        }
    }
}
