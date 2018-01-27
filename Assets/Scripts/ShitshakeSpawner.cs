using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShitshakeSpawner : MonoBehaviour {

    public GameObject prefab;

    private GameObject player;

    private int countdown = 0;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player_alien");
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Mathf.Abs(player.transform.position.x - transform.position.x) <= 20 && Mathf.Abs(player.transform.position.x - transform.position.x) > 5)
        {
            if (countdown == 0)
            {
                GameObject t = Instantiate(prefab, transform.position, transform.rotation);
                countdown = 150;
            }
            else
            {
                countdown--;
            }
        }

    }
}
