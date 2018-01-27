using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    private Vector2 velocity;

    //public float smoothTimeY;
    public float smoothTimeX;

    public GameObject player;

    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {

        float posX = Mathf.SmoothDamp(transform.position.x, player.transform.position.x, ref velocity.x, smoothTimeX);
        //float posY = Mathf.SmoothDamp(transform.position.y, player.transform.position.y, ref velocity.y, smoothTimeY);

        transform.position = new Vector3(posX, transform.position.y, transform.position.z);

    }
}
