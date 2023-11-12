using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoved : MonoBehaviour
{
    public Rigidbody rb;
    public Transform BodyPlayer;
    public float MovedForce;
    public float FrigtionForce;
    public float JumpForce;
    public bool IsGrounded;
    public float MaxSpeed = 5.0f; 
    

    private void FixedUpdate()
    {
        //Moved
        
        float speedMultiplier = 1.0f;
        if (!IsGrounded)
        {
            speedMultiplier = 0.7f;
            if (Mathf.Abs(rb.velocity.x) > MaxSpeed && Mathf.Abs(Input.GetAxis("Horizontal")) > 0)
            {
                speedMultiplier = 0;
            }
        }

        
        rb.AddForce(Input.GetAxis("Horizontal") * MovedForce * speedMultiplier, 0.0f, 0.0f, ForceMode.VelocityChange);
        if (IsGrounded)
        {
            rb.AddForce(-rb.velocity.x * FrigtionForce, 0.0f,0.0f, ForceMode.VelocityChange);
        }
        



    }

    private void Update()
    {
        //Jump
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded)
        {
            rb.AddForce(0.0f, JumpForce, 0.0f, ForceMode.VelocityChange);
        }

        if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.LeftControl))
        {
            BodyPlayer.localScale = Vector3.Lerp(BodyPlayer.localScale, new Vector3(1.0f, 0.5f, 1.0f), 15 * Time.deltaTime);
        }
        else
        {
            BodyPlayer.localScale = Vector3.Lerp(BodyPlayer.localScale, Vector3.one, 15 * Time.deltaTime);
        }
    }

    private void OnCollisionStay(Collision other)
    {
        
        if (Vector3.Angle(other.contacts[0].normal, Vector3.up) <= 45.0f)
        {
            IsGrounded = true;
        }
    }

    private void OnCollisionExit(Collision other)
    {
        IsGrounded = false;
    }
}
