using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TexturePanController : MonoBehaviour {

    public GameObject parent;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerStay(Collider other)
    {
        if (other.tag != "Player" && other.name != "CameraZoom" && other.name != "Switch" && this.GetComponentInParent<Rigidbody>().detectCollisions)
        {
            Debug.Log(other.name);
            this.parent.GetComponent<PlayerController>().canPan = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag != "Player" && other.name != "CameraZoom" && other.name != "Switch" && this.GetComponentInParent<Rigidbody>().detectCollisions)
        {
            Debug.Log("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" + other.name);
            this.parent.GetComponent<PlayerController>().canPan = true;
        }
    }

}
