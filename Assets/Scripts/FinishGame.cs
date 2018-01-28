using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishGame : MonoBehaviour
{
    public GameObject Canvas;
    public GameObject Music;
    public GameObject TeleportDestination;
    public GameObject FinalRoom;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            
            Canvas.SetActive(false);
            FinalRoom.SetActive(true);
            other.transform.position = TeleportDestination.transform.position;

        }
    }
}
