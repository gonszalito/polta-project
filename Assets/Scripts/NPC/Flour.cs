using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;

public class Flour : MonoBehaviour
{
    private GameObject triggerContainer;

    private void Start() 
    {
        triggerContainer = this.gameObject;
    }

    private void Update() 
    {
      // bool acorn = ((Ink.Runtime.BoolValue) DialogueManager
      // .GetInstance()
      // .GetVariableState("flour")).value;

      
      // if (acorn)
      // {
      //   // trigger.enabled = false; 
      //   triggerContainer.SetActive(false);
      // }
    }
}
