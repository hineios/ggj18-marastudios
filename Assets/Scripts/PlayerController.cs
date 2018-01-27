using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float FallMultiplier = 2.5f;
    public float LowJumpMultiplier = 2f;
    public float JumpVelocity = 7f;
    public int MaxJumps = 1;
    public int JumpCount = 0;

    public float HorizontalSpeed = 2.0f;

    private Rigidbody rig;

    private void Start()
    {
        rig = GetComponent<Rigidbody>();
        JumpCount = MaxJumps;
    }

    void Update()
    {
        float hAxis = Input.GetAxis("Horizontal");
        float vAxis = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(hAxis, 0.0f, 0.0f) * HorizontalSpeed * Time.deltaTime;
        rig.transform.Translate(movement);

        if (Input.GetButtonDown("Jump"))
        {
            if (JumpCount > 0)
            {
                rig.velocity = Vector3.up * JumpVelocity;
                JumpCount -= 1;
            }
        }

        
        // Make jump better, slow down up, fasten down
        if(rig.velocity.y < 0)
        {
            rig.velocity += Vector3.up * Physics.gravity.y * (FallMultiplier - 1) * Time.deltaTime;
        } else if(rig.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            rig.velocity += Vector3.up * Physics.gravity.y * (LowJumpMultiplier - 1) * Time.deltaTime;
        }
    }
    void OnCollisionEnter(Collision Col)
    {
        if (Col.gameObject.layer == LayerMask.NameToLayer("Default"))
        {
            JumpCount = MaxJumps;
        }
    }
}