using UnityEngine;

// This script is a basic 2D character controller that allows
// the player to run and jump. It uses Unity's new input system,
// which needs to be set up accordingly for directional movement
// and jumping buttons.

[RequireComponent(typeof(Rigidbody2D))]
public class CharacterController2D : MonoBehaviour
{
    [SerializeField] Transform Position;

    [Header("Movement Params")]
    public float runSpeed = 6.0f;
    public float jumpSpeed = 8.0f;
    public float gravityScale = 20.0f;

    // components attached to player
    private CapsuleCollider2D playerCollider; 
    private Rigidbody2D myRigidbody;
    private Animator animator;

    private bool isMovingTowards = false;
    // other
    // private bool isGrounded = false;

    private void Awake()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<CapsuleCollider2D>();
        animator = GetComponent<Animator>();

        myRigidbody.gravityScale = gravityScale;
    }

    private void FixedUpdate()
    { 

       
        if (DialogueManager.GetInstance().dialogueIsPlaying)
        {
            animator.SetBool("isWalking", false);
            // animator.Play("idle");
            return;
        }
        
        if (isMovingTowards)
        {
            return;
        }

        animator.enabled = true;
        // UpdateIsGrounded();

        HandleHorizontalMovement();

        HandleJumping();

        FlipSprite();
    }

    // private void UpdateIsGrounded()
    // {

    //     if(!playerCollider.IsTouchingLayers(LayerMask.GetMask("Ground"))){ return; }
    //     else
    //     {
    //         this.isGrounded = true;
    //     }
    //     if (this.isGrounded){

    //     }

    // }

    private void HandleHorizontalMovement()
    {
        Vector2 moveDirection = InputManager.GetInstance().GetMoveDirection();
        myRigidbody.velocity = new Vector2(moveDirection.x * runSpeed, myRigidbody.velocity.y);

        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;
        animator.SetBool("isWalking", playerHasHorizontalSpeed);

        if (playerHasHorizontalSpeed)
        {
            // SoundManager.PlaySound("Walking");
        }
    }

    private void HandleJumping()
    {
        bool jumpPressed = InputManager.GetInstance().GetJumpPressed();

        if(!playerCollider.IsTouchingLayers(LayerMask.GetMask("Ground"))){ return; }
        

        if (jumpPressed)
        {
            // isGrounded = false;
            myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpSpeed);
        }
    }

    private void FlipSprite()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;

        if(playerHasHorizontalSpeed)
        {
            transform.localScale = new Vector2 (Mathf.Sign(myRigidbody.velocity.x), 1f);
        }
    }

    // Function to move to position when talking
    // public void MoveToPoint(Transform movePosition)
    // {
        
    //     while (movePosition.position != myRigidbody.transform.position){
    //         Vector2 moveDirection;
    //         if (movePosition.position.x > myRigidbody.transform.position.x){
    //             moveDirection = new Vector2(1.0f,0f);
    //         }
    //         else
    //         {
    //             moveDirection = new Vector2(-1.0f,0f);
    //         }
    //         myRigidbody.transform.position = Vector2.Lerp(myRigidbody.transform.position, movePosition.position, 1.5f);
    //         isMovingTowards = true;
    //     }
       
    //     isMovingTowards = false;
        
    // }

   
}