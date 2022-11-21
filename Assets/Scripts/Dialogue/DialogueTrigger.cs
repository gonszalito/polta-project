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
    [SerializeField] private Animator animator;

    [Header ("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;

    // [Header ("Distance to move")]
    // [SerializeField] private float distanceToMove = 10;

    [Header("Position to move")]
    [SerializeField] Transform[] Position;

    [Header("Behind of Character")]
    // [SerializeField] GameObject behindTrigger;

    private Collider2D playerCollider;
    private GameObject spriteObject;
    // private Collider2D behindCollider;
    private bool questIndicatorState;
    private GameObject player;
    private BoxCollider2D interactTrigger;

    // private bool isBehind = false;
    // private bool facingBehind = false;
    private bool playerInRange;

      public bool playerIsMoving { get; private set; }

    private void Awake() 
    {
        //Collider to trigger behind moved to own script
        // behindCollider = behindTrigger.GetComponent<BoxCollider2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerCollider = player.GetComponent<CapsuleCollider2D>();
        // spriteObject = GameObject.Find("Sprite");
        interactTrigger = this.GetComponent<BoxCollider2D>();
        playerInRange = false;
        visualCue.SetActive(false);
    }
    
    private void Update() {
        ChangeVisualCue();
        // CheckBehind();
        if (questIndicatorState && !playerInRange && !DialogueManager.GetInstance().dialogueIsPlaying)
        {
            visualCue.SetActive(true);
        }
        else if (playerInRange && DialogueManager.GetInstance().dialogueIsPlaying)
        {
            visualCue.SetActive(false);
        }
        else
        {
            visualCue.SetActive(false);
        }

        if (playerInRange && !DialogueManager.GetInstance().dialogueIsPlaying && PauseMenu.GetInstance().pauseIsOn == false)
        {
            visualCue.SetActive(true);
            ChangeVisualCue();

            if (InputManager.GetInstance().GetInteractPressed())
            {
                // if (isBehind)
                // {
                //     // FlipSprite();
                //     // facingBehind = true;
                // }
                DialogueManager.GetInstance().EnterDialogueMode(inkJSON);
            }
        }
        else if (!questIndicatorState)
        {
            visualCue.SetActive(false);
        }

        // if (facingBehind == true && !DialogueManager.GetInstance().dialogueIsPlaying)
        // {
        //     FlipSprite();
        //     facingBehind = false;
        // }
        

              
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

    private void CheckDictionary()
    {
        
    }

    private void ChangeVisualCue()
    {
    //     string quest_giver = ((Ink.Runtime.BoolValue) DialogueManager
    //     .GetInstance()
    //     .GetVariableState("quest_giver")).value;

        bool quest_giver_coco = ((Ink.Runtime.BoolValue) DialogueManager
        .GetInstance()
        .GetVariableState("quest_giver_coco")).value;

        bool talked_coco = ((Ink.Runtime.BoolValue) DialogueManager
        .GetInstance()
        .GetVariableState("talked_coco")).value;

        bool quest_giver_boni = ((Ink.Runtime.BoolValue) DialogueManager
        .GetInstance()
        .GetVariableState("quest_giver_boni")).value;

        bool talked_boni = ((Ink.Runtime.BoolValue) DialogueManager
        .GetInstance()
        .GetVariableState("talked_boni")).value;

        bool quest_giver_feru = ((Ink.Runtime.BoolValue) DialogueManager
        .GetInstance()
        .GetVariableState("quest_giver_feru")).value;

        bool talked_feru = ((Ink.Runtime.BoolValue) DialogueManager
        .GetInstance()
        .GetVariableState("talked_feru")).value;

        bool quest_giver_aru = ((Ink.Runtime.BoolValue) DialogueManager
        .GetInstance()
        .GetVariableState("quest_giver_aru")).value;

        bool talked_aru = ((Ink.Runtime.BoolValue) DialogueManager
        .GetInstance()
        .GetVariableState("talked_aru")).value;

        bool quest_giver_venari = ((Ink.Runtime.BoolValue) DialogueManager
        .GetInstance()
        .GetVariableState("quest_giver_venari")).value;

        bool talked_venari = ((Ink.Runtime.BoolValue) DialogueManager
        .GetInstance()
        .GetVariableState("talked_venari")).value;

        bool quest_giver_guri = ((Ink.Runtime.BoolValue) DialogueManager
        .GetInstance()
        .GetVariableState("quest_giver_guri")).value;

        bool talked_guri = ((Ink.Runtime.BoolValue) DialogueManager
        .GetInstance()
        .GetVariableState("talked_guri")).value;

        bool quest_giver_object_flour = ((Ink.Runtime.BoolValue) DialogueManager
        .GetInstance()
        .GetVariableState("quest_giver_object_flour")).value;

        bool quest_giver_trigger_quit = ((Ink.Runtime.BoolValue) DialogueManager
        .GetInstance()
        .GetVariableState("quest_giver_trigger_quit")).value;

        bool state_village_bread_flour = ((Ink.Runtime.BoolValue) DialogueManager
        .GetInstance()
        .GetVariableState("state_village_bread_flour")).value;

        if(interactObject.name == "Coco")
        {
         
            if (quest_giver_coco)
            {
                questIndicatorState = true;
                animator.Play("QuestDialogue");

            }
            else if(!talked_coco && playerInRange)
            {
                questIndicatorState = false;
                animator.Play("ActiveDialogue");
            }
            else if (playerInRange)
            {
                questIndicatorState = false;
                animator.Play("InactiveDialogue");
            }
        }

        if(interactObject.name == "Boni")
        {
         
            if (quest_giver_boni)
            {
                questIndicatorState = true;
                animator.Play("QuestDialogue");

            }
            else if(!talked_boni && playerInRange)
            {
                questIndicatorState = false;
                animator.Play("ActiveDialogue");
            }
            else if (playerInRange)
            {
                questIndicatorState = false;
                animator.Play("InactiveDialogue");
            }
        }


        if(interactObject.name == "Aru")
        {
            if (quest_giver_aru)
            {
                questIndicatorState = true;
                animator.Play("QuestDialogue");
            }
            else if(!talked_aru && playerInRange)
            {
                questIndicatorState = false;
                animator.Play("ActiveDialogue");
            }
            else if (playerInRange)
            {
                questIndicatorState = false;
                animator.Play("InactiveDialogue");
            }
        }

        if(interactObject.name == "Feru")
        {
            if (quest_giver_feru)
            {
                questIndicatorState = true;
                animator.Play("QuestDialogue");
            }
            else if(!talked_feru && playerInRange)
            {
                questIndicatorState = false;
                animator.Play("ActiveDialogue");
            }
            else if (playerInRange)
            {
                questIndicatorState = false;
                animator.Play("InactiveDialogue");
            }
        }
        
        if(interactObject.name == "Guri")
        {
            if (quest_giver_guri)
            {
                questIndicatorState = true;
                animator.Play("QuestDialogue");
            }
            else if(!talked_guri && playerInRange)
            {
                questIndicatorState = false;
                animator.Play("ActiveDialogue");
            }
            else if (playerInRange)
            {
                questIndicatorState = false;
                animator.Play("InactiveDialogue");
            }
        }

        if(interactObject.name == "Venari")
        {
            if (quest_giver_venari)
            {
                questIndicatorState = true;
                animator.Play("QuestDialogue");
            }
            else if(!talked_venari && playerInRange)
            {
                questIndicatorState = false;
                animator.Play("ActiveDialogue");
            }
            else if (playerInRange)
            {
                questIndicatorState = false;
                animator.Play("InactiveDialogue");
            }
        }

        if(interactObject.name == "Flour")
        {
            if (quest_giver_object_flour)
            {
                questIndicatorState = true;
                animator.Play("QuestDialogue");
            }
            else if (playerInRange)
            {
                questIndicatorState = false;
                animator.Play("ActiveDialogue");
            }
            // else 
            // {
            //     animator.Play("InactiveDialogue");
            // }
        }
        
    
    }

    // private void FlipSprite()
    // {
    //     Vector3 rotateScale = spriteObject.transform.localScale;
    //     rotateScale.x *= -1;
    //     spriteObject.transform.localScale = rotateScale;
    // }

    // private void CheckBehind()
    // {
    //     if (behindCollider.IsTouching(playerCollider))
    //     {
    //         isBehind = true;
    //     }
    //     else
    //     {
    //         isBehind = false;
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
