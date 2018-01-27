using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class TelevisionMovement : MonoBehaviour {

    // Use this for initialization

    public Transform anchor;

    public string movementDir;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (this.transform.position.y <= anchor.transform.position.y && movementDir == "Down")
        {

            if (!GameObject.Find("Screen").GetComponent<VideoPlayer>().isPlaying)
                GameObject.Find("Screen").GetComponent<VideoPlayer>().Play();
           return;
        }

        if (this.transform.position.y >= anchor.transform.position.y && movementDir == "Up")
        {
            if (GameObject.Find("Screen").GetComponent<VideoPlayer>().isPlaying)
                GameObject.Find("Screen").GetComponent<VideoPlayer>().Stop();
            return;
        }


        else if(movementDir == "Up")
        {
            this.transform.Translate(0.0f, -0.01f, 0.0f);
        } else if(movementDir == "Down")
        {
            this.transform.Translate(0.0f, 0.01f, 0.0f);
        }
       
	}


    public void Move(string dir)
    {
        movementDir = dir;
    }
}
