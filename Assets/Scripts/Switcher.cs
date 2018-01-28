using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switcher : MonoBehaviour {

    public GameObject activatables, deactivatables;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Talk")
        {
            activatables.SetActive(true);
            deactivatables.SetActive(false);

        }
    }
}
