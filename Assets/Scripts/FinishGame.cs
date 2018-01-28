using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishGame : MonoBehaviour
{
    public GameObject Canvas;
    public GameObject Music;
    public GameObject TeleportDestination;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Canvas.SetActive(false);
            other.transform.position = TeleportDestination.transform.position;
        }
    }
}
