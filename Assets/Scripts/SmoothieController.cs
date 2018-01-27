using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothieController : MonoBehaviour {

    public float smoothieStrenght;

    private int timeout = 0;

    private Rigidbody rig;
    // Use this for initialization
    void Start()
    {
        rig = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(timeout == 10)
        {
            Destroy(this);
        }
        else
        {
            rig.AddForce(Vector3.right * -smoothieStrenght);
            timeout++;
        }
    }
}
