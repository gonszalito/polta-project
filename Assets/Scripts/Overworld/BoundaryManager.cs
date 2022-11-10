using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BoundaryManager : MonoBehaviour
{
    public GameObject villageEnterTrigger;
    public GameObject forrestEnterTrigger;

    // Update is called once per frame
    void Update()
    {
        Debug.Log(((Ink.Runtime.BoolValue) DialogueManager
        .GetInstance()
        .GetVariableState("state_village_leave_all")).value);
        DeactivateBoundary();
    }

    void DeactivateBoundary()
    {
        if (((Ink.Runtime.BoolValue) DialogueManager
        .GetInstance()
        .GetVariableState("state_village_leave_all")).value)
        {
            Debug.Log("BOUNDARY DEACTIVATED");
            villageEnterTrigger.SetActive(false);
            forrestEnterTrigger.SetActive(true);
        }
    }
}
