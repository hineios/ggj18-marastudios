using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    // Jump Stuff
    public float FallMultiplier = 2.5f;
    public float LowJumpMultiplier = 2f;
    public float JumpVelocity = 7f;
    public int MaxJumps = 1;
    public int JumpCount = 0;
    private bool Grounded;

    private float baseY;

    private Vector2 newOffset;

    // Move Stuff
    public float HorizontalSpeed = 2.0f;

    private Rigidbody rb;
    private SpriteRenderer sr;
    private Animator anim;

    public RawImage TransTex;

    private Vector3 movement;

    public bool canPan;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        JumpCount = MaxJumps;
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        baseY = 0;
        canPan = true;
       
    }

    void Update()
    {
        //Move Horizontally
        float hAxis = Input.GetAxis("Horizontal");
        movement = new Vector3(hAxis, 0.0f, 0.0f) * HorizontalSpeed * Time.deltaTime;
        rb.transform.Translate(movement);

        // Update animator stuff
        anim.SetBool("Walking", Math.Abs(movement.x) != 0);

        //TODO: FIX
       if(canPan)
        {
            newOffset += new Vector2(movement.x * 0.007f, 0);
            if (TransTex != null) TransTex.material.SetTextureOffset("_Noise", newOffset);
        }


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
                //newOffset = new Vector2(newOffset.x, -rb.velocity.y * 0.00000001f);
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
        if (Col.gameObject.tag == "Platform")
        {
            transform.parent = null;
        }
    }
}