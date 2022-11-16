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

    private bool questIndicatorState;
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
        ChangeVisualCue();
        if (questIndicatorState && !playerInRange && !DialogueManager.GetInstance().dialogueIsPlaying)
        {
            visualCue.SetActive(true);
        }
        else
        {
            visualCue.SetActive(false);
        }

        if (playerInRange && !DialogueManager.GetInstance().dialogueIsPlaying)
        {
            visualCue.SetActive(true);
            ChangeVisualCue();

            if (InputManager.GetInstance().GetInteractPressed())
            {
                DialogueManager.GetInstance().EnterDialogueMode(inkJSON);
            }
        }
        else if (!questIndicatorState)
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
            else if(!talked_coco)
            {
                questIndicatorState = false;
                animator.Play("ActiveDialogue");
            }
            else 
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
            else if(!talked_boni)
            {
                questIndicatorState = false;
                animator.Play("ActiveDialogue");
            }
            else 
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
            else if(!talked_aru)
            {
                questIndicatorState = false;
                animator.Play("ActiveDialogue");
            }
            else 
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
            else if(!talked_feru)
            {
                questIndicatorState = false;
                animator.Play("ActiveDialogue");
            }
            else 
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
            else if(!talked_guri)
            {
                questIndicatorState = false;
                animator.Play("ActiveDialogue");
            }
            else 
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
            else if(!talked_venari)
            {
                questIndicatorState = false;
                animator.Play("ActiveDialogue");
            }
            else 
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
            else
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
