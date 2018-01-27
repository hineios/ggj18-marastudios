using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float hSpeed = 2.0f;
    public float vSpeed = 15.0f;

    float distToGround;

    public LayerMask groundLayers;
    private Rigidbody rig;
    private SphereCollider col;

    private void Start()
    {
        distToGround = GetComponent<Collider>().bounds.extents.y;
      

        rig = GetComponent<Rigidbody>();
        col = GetComponent<SphereCollider>();
    }

    void Update()
    {
        float hAxis = Input.GetAxis("Horizontal");
        float vAxis = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(hAxis, 0.0f, 0.0f) * hSpeed * Time.deltaTime;


        Debug.Log(Input.GetJoystickNames()[0]);

        if (IsGrounded() && ((Input.GetJoystickNames()[0].Contains("Xbox") && Input.GetKeyDown("joystick button 0")) || (Input.GetJoystickNames()[0].Contains("360") && Input.GetKeyDown("joystick button 1"))))
        {
            rig.AddForce(Vector3.up * vSpeed, ForceMode.Impulse);
            //rig.velocity = Vector3.up * vSpeed;
        }

        rig.transform.Translate(movement);

    }

    private bool IsGrounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f);
    }
}