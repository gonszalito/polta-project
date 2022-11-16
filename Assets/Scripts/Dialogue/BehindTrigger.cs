using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehindTrigger : MonoBehaviour
{
    [SerializeField] private GameObject spriteObject;
    // [SerializeField] private 

    private bool isBehind = false;
    private bool facingBehind = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (DialogueManager.GetInstance().dialogueIsPlaying && isBehind && facingBehind == false)
        {
            Debug.Log("flip works");
            FlipSprite();
            facingBehind = true;
        }

        if (facingBehind == true && !DialogueManager.GetInstance().dialogueIsPlaying)
        {
            FlipSprite();
            facingBehind = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            // Debug.Log("isBehind");
            isBehind = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        if (other.gameObject.tag == "Player")
        {
            isBehind = false;
        }
    }

    private void FlipSprite()
    {
        Vector3 rotateScale = spriteObject.transform.localScale;
        rotateScale.x *= -1;
        spriteObject.transform.localScale = rotateScale;
    }
}
