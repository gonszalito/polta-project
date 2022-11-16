using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EscapeKey : MonoBehaviour
{
    public GameObject showObject;
    public GameObject hideObject;
    public GameObject firstSelected;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SelectedButton(firstSelected);
            hideObject.SetActive(false);
            showObject.SetActive(true);
        }
    }
    private void SelectedButton(GameObject firstSelected)
    {
        // clear selected button
        EventSystem.current.SetSelectedGameObject(null);
        // set a new selected button
        EventSystem.current.SetSelectedGameObject(firstSelected);
    }
}
