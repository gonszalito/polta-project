using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [Header("Game Objects")]
    [SerializeField] private GameObject interactObject;
    // [SerializeField] private GameObject player;

    [Header("Visual Cue")]
    [SerializeField] private GameObject visualCue;

    [Header ("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;

    // [Header ("Distance to move")]
    // [SerializeField] private float distanceToMove = 10;

    [Header("Position to move")]
    [SerializeField] Transform[] Position;

    private GameObject player;
    private BoxCollider2D interactTrigger;
    private bool playerInRange;

      public bool playerIsMoving { get; private set; }

    private void Awake() 
    {
        player = GameObject.FindGameObjectWithTag("Player");
        interactTrigger = this.GetComponent<BoxCollider2D>();
        playerInRange = false;
        visualCue.SetActive(false);
    }
    
    private void Update() {
  
        if (playerInRange && !DialogueManager.GetInstance().dialogueIsPlaying)
        {
            visualCue.SetActive(true);
            if (InputManager.GetInstance().GetInteractPressed())
            {

          
                DialogueManager.GetInstance().EnterDialogueMode(inkJSON);
            }
        }
        else
        {
            visualCue.SetActive(false);
        }
              
    }

    // private void MoveToPosition()
    // {
    //     CharacterController2D controller = player.GetComponent<CharacterController2D>();
    //     float distance = interactObject.transform.position.x - player.transform.position.x;
    //     if (Position.Length != 0)
    //     {
    //         if (distance > 0)
    //         {
    //             controller.MoveToPoint(Position[0]);
    //         }
    //         else
    //         {
    //             controller.MoveToPoint(Position[1]);
    //         }
    //     }

    // }

    private void OnTriggerEnter2D(Collider2D other) 
    {    
        if (other.gameObject.tag == "Player")
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        if (other.gameObject.tag == "Player")
        {
            playerInRange = false;
        }
    }
}
