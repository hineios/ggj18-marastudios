using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float hSpeed = 2.0f;
    public float vSpeed = 15.0f;

    public LayerMask groundLayers;
    private Rigidbody rig;
    private SphereCollider col;

    private void Start()
    {
        rig = GetComponent<Rigidbody>();
        col = GetComponent<SphereCollider>();
    }

    void Update()
    {
        float hAxis = Input.GetAxis("Horizontal");
        float vAxis = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(hAxis, 0.0f, 0.0f) * hSpeed * Time.deltaTime;

        if (IsGrounded() && Input.GetButtonDown("Jump"))
        {
            rig.velocity = Vector3.up * vSpeed;
        }

        rig.transform.Translate(movement);

    }

    private bool IsGrounded()
    {
        return Physics.CheckCapsule(col.bounds.center, new Vector3(col.bounds.center.x, col.bounds.min.y, col.bounds.center.z), col.radius * .2f, groundLayers);
    }

}