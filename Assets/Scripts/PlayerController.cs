using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Jump Stuff
    public float FallMultiplier = 2.5f;
    public float LowJumpMultiplier = 2f;
    public float JumpVelocity = 7f;
    public int MaxJumps = 1;
    public int JumpCount = 0;
    private bool Grounded;

    // Move Stuff
    public float HorizontalSpeed = 2.0f;

    private Rigidbody rb;
    private SpriteRenderer sr;
    private Animator anim;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        JumpCount = MaxJumps;
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        //Move Horizontally
        float hAxis = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(hAxis, 0.0f, 0.0f) * HorizontalSpeed * Time.deltaTime;
        rb.transform.Translate(movement);

        // Update animator stuff
        anim.SetBool("Walking", Math.Abs(movement.x) != 0);
        
        
        // Flip player according to direction
        bool flip = sr.flipX ? movement.x < 0.01f : movement.x > 0.01f;
        if (flip)
        {
            sr.flipX = !sr.flipX;
        }

        if (Input.GetButtonDown("Jump"))
        {
            if (JumpCount > 0)
            {
                anim.SetBool("Grounded", false);
                anim.SetBool("Jumping", true);
                rb.velocity = Vector3.up * JumpVelocity;
                JumpCount -= 1;
            }
        }

        // Make jump better, slow down up, fasten down
        if(rb.velocity.y < 0)
        {
            rb.velocity += Vector3.up * Physics.gravity.y * (FallMultiplier - 1) * Time.deltaTime;
        } else if(rb.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            rb.velocity += Vector3.up * Physics.gravity.y * (LowJumpMultiplier - 1) * Time.deltaTime;
        }
    }
    void OnCollisionEnter(Collision Col)
    {
        if (Col.gameObject.layer == LayerMask.NameToLayer("Default"))
        {
            anim.SetBool("Jumping", false);
            anim.SetBool("Grounded", true);
            JumpCount = MaxJumps;
        }

        if (Col.gameObject.tag == "Platform")
        {
            transform.parent = Col.transform;
        }
    }

    void OnCollisionExit(Collision Col)
    {
        Debug.Log(Col);

        if (Col.gameObject.tag == "Platform")
        {
            transform.parent = null;
        }
    }
}