using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MilkshakeSpawner : MonoBehaviour {

    public GameObject milkShake, shitShake;

    private GameObject player;

    private int whichAlien;

    private int countdown = 10;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player_human");

        whichAlien = Random.Range(0, 1);
    }
	
	// Update is called once per frame
	void Update ()
    {

        if (Mathf.Abs(player.transform.position.x - transform.position.x) <= 30 && Mathf.Abs(player.transform.position.x - transform.position.x) > 5)
        {
            if (countdown == 0)
            {   if (whichAlien == 0)Instantiate(milkShake, transform.position, Quaternion.identity);
                else Instantiate(shitShake, new Vector3(transform.position.x, transform.position.y + 37, transform.position.z), Quaternion.identity);
                whichAlien = Random.Range(0, 2);
                countdown = Random.Range(50, 250);
            }
            else
            {
                countdown--;
            }
        }

    }
}
