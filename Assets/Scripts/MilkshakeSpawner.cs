using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MilkshakeSpawner : MonoBehaviour {

    public GameObject prefab;

    private GameObject player;

    private int countdown = 0;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player_human");
        prefab = GameObject.Find("Milkshake");
    }
	
	// Update is called once per frame
	void Update ()
    {

        if (Mathf.Abs(player.transform.position.x - transform.position.x) <= 20 && Mathf.Abs(player.transform.position.x - transform.position.x) > 5)
        {
            if (countdown == 0)
            {
                Instantiate(prefab, transform.position, Quaternion.identity);
                countdown = 150;
            }
            else
            {
                countdown--;
            }
        }

    }
}
