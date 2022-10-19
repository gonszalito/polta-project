using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float runSpeed = 5.0f;
    [SerializeField] float jumpSpeed = 5.0f;
    Vector2 moveInput;
    Rigidbody2D myRigidbody;
    CapsuleCollider2D playerCollider;
    Animator animator;

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<CapsuleCollider2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Run();
        FlipSprite();
    }

    void OnMove(InputValue value)    
    {
        moveInput = value.Get<Vector2>();
        Debug.Log(moveInput);
    }

       void Run()
    {
        Vector2 playerVelocity = new Vector2 (moveInput.x * runSpeed, myRigidbody.velocity.y);
        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;
        myRigidbody.velocity = playerVelocity;

        animator.SetBool("isWalking", playerHasHorizontalSpeed);
    }

       void OnJump(InputValue value)
    {  
        if(!playerCollider.IsTouchingLayers(LayerMask.GetMask("Ground"))){ return; }

        if(value.isPressed)
        {
        myRigidbody.velocity += new Vector2 (0f, jumpSpeed);

        // myRigidbody.AddForce(new Vector2(0, jumpSpeed), ForceMode2D.Impulse);

        }
    }

    void FlipSprite()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;

        if(playerHasHorizontalSpeed)
        {
            transform.localScale = new Vector2 (Mathf.Sign(myRigidbody.velocity.x), 1f);
        }
    }
}

