using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEnterChildEnabler : MonoBehaviour
{
    public SpriteRenderer stair;
    private void OnTriggerEnter2D(Collider2D other) 
    {
        ChildEnabler();
        stair.sortingOrder = 15;      
    }

    private void ChildEnabler()
    {
        for(int i=0; i< transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(true);
        }
    }
}
