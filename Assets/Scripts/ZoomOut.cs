using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomOut : MonoBehaviour {

    public Camera cam;
    public GameObject x;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerStay(Collider other)
    {
        float hAxis = Input.GetAxis("Horizontal");
        if (other.gameObject.tag == "Player" && cam.fieldOfView < 77)
        {
            if (hAxis > 0)
            {
                cam.fieldOfView += Time.deltaTime * 15;

            }
            if (hAxis < 0)
            {
                cam.fieldOfView -= Time.deltaTime * 15;
            }
        }
        else x.GetComponent<TransitionController>().startShader();
    }
}
