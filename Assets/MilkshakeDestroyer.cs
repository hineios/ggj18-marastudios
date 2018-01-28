using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MilkshakeDestroyer : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.transform.name.Contains("shake"))
        {
            Debug.Log(other.gameObject.transform.name);
            Destroy(other.gameObject);
        }
    }
}
