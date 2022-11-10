using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillageEnterTrigger : MonoBehaviour
{
    public GameObject villageExitBoundary;

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Player"))
        {
            villageExitBoundary.SetActive(true);
        }
    }
}
