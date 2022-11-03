using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stairs : MonoBehaviour
{
    public SpriteRenderer stair;
    public CapsuleCollider2D playerCollision;
    public Rigidbody2D rb2d;

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.CompareTag("Player") && !playerCollision.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            Debug.Log("Stair On");
            stair.sortingOrder = 15;
            rb2d.gravityScale = 3f;
        }
    }

    private void OnCollisionExit2D(Collision2D other) 
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Stair Off");
            stair.sortingOrder = 1;
            rb2d.gravityScale = 8f;
        }
    }
}
