using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlsTutorial : MonoBehaviour
{
    [SerializeField] private GameObject toBeUpdated;
    [SerializeField] private GameObject dialogueBox;

    private void Start() 
    {
        // toBeUpdated = this.gameObject;
    }

    private void Update() 
    {
      bool state_intro_cutscene = ((Ink.Runtime.BoolValue) DialogueManager
      .GetInstance()
      .GetVariableState("state_intro_cutscene")).value;

      
      if (state_intro_cutscene && !dialogueBox.activeSelf) 
      {
        toBeUpdated.SetActive(true);
        
      }
    }
}
