using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YMovingPlatform : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //transform.position = new Vector3(Mathf.PingPong(Time.time, 1), transform.position.y, transform.position.z);
        transform.Translate(transform.up * Mathf.Cos(Time.time) * Time.deltaTime);
    }
}
