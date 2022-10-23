using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerExitObjectDisabler : MonoBehaviour
{
    public SpriteRenderer stair;

    private void OnTriggerExit2D(Collider2D other) 
    {
        this.gameObject.SetActive(false);
        stair.sortingOrder = 2;   
    }
}
