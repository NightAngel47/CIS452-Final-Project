/*
 * 
 * 
 * 
 * 
 */

using System;
using UnityEngine;

/*
 * Connor Wolf, Steven Drovie
 * Player_Movement.cs
 * CIS452 - Final Project
 * Handles basic player movement and jumping
 */

public class Player_Movement : MonoBehaviour
{
    #region Publics Variables
    public float moveSpeed;
    public float jumpHeight;
    public LayerMask mask;
    #endregion

    #region Private Variables
    private Rigidbody2D rb;
    private Vector3 settingVelocity = Vector3.zero;
    private Animator anim;
    #endregion

    #region Unity Callbacks
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        HorizontalCalculation();
        JumpingCalculation();
        
        AnimationUpdate();

        rb.velocity = new Vector2(settingVelocity.x, settingVelocity.y + rb.velocity.y);
    }

    private void FixedUpdate()
    {
       // rb.velocity = new Vector2(settingVelocity.x, settingVelocity.y + rb.velocity.y);
    }

    #endregion

    #region Player_Movement Functions
    void HorizontalCalculation()
    {
        float horInput = Input.GetAxis("Horizontal");

        settingVelocity = Vector3.right * horInput * moveSpeed * Time.fixedDeltaTime;
    }

    void JumpingCalculation()
    {
        bool canJump = Physics2D.Raycast(transform.position, Vector2.down, 1f, mask);
        if (canJump)
        {
            if (Input.GetButtonDown("Jump"))
            {
                settingVelocity += Vector3.up * jumpHeight;
            }
        }

        if (rb.velocity.y > 0)
        {
            if (Input.GetButton("Jump"))
            {
                rb.gravityScale = 0.6f;
            } else rb.gravityScale = 1f;
        } else rb.gravityScale = 1;
        
    }
    #endregion

    #region Animation Functions
    void AnimationUpdate()
    {
        SetDirection();
        SetMoving();
        SetAirborne();
    }

    void SetDirection()
    {
        if (rb.velocity.x != 0)
            GetComponent<SpriteRenderer>().flipX = Mathf.Sign(rb.velocity.x) == -1;
    }

    void SetMoving()
    {
        anim.SetBool("isMoving", Mathf.Abs(rb.velocity.x) > 0);
    }

    void SetAirborne()
    {
        anim.SetBool("isAirborne", !Physics2D.Raycast(transform.position, Vector2.down, 1f, mask));
    }
    #endregion
}
