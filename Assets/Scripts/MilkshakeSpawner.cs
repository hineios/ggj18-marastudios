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
    }
	
	// Update is called once per frame
	void Update ()
    {

        if (Mathf.Abs(player.transform.position.x - transform.position.x) <= 30 && Mathf.Abs(player.transform.position.x - transform.position.x) > 5)
        {
            if (countdown == 0)
            {
                Instantiate(prefab, transform.position, Quaternion.identity);
                countdown = Random.Range(150, 200);
            }
            else
            {
                countdown--;
            }
        }

    }
}
