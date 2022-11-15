using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerExitObjectDisabler : MonoBehaviour
{
    public SpriteRenderer stair;
    public CapsuleCollider2D playerCollision;

    private void OnTriggerExit2D(Collider2D other) 
    {
        if(other.CompareTag("Player"))
        {
            Debug.Log("Stair Off");
            stair.sortingOrder = 1;
            this.gameObject.SetActive(false);
            stair.sortingOrder = 2;
        }
    }
}
