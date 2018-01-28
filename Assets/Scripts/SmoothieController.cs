using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothieController : MonoBehaviour {

    public float smoothieStrenght;

    private Rigidbody rig;
    // Use this for initialization
    void Start()
    {
        rig = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(- transform.right *  Time.deltaTime * smoothieStrenght);
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "player")
        {
            collision.gameObject.transform.position = new Vector3(this.transform.position.x - 1, collision.gameObject.transform.position.y, collision.gameObject.transform.position.z);
        }
    }
}
