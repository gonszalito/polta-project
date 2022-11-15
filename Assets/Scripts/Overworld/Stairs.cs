using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stairs : MonoBehaviour
{
    public CapsuleCollider2D playerCollision;
    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Physics2D.gravity = new Vector2(10f, -10f);
        }
    }

    private void OnCollisionExit2D(Collision2D other) 
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Physics2D.gravity = new Vector2(0f, -10f);
        }
    }
}
