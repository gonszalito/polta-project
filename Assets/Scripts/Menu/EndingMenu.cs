using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class EndingMenu : MonoBehaviour
{
    public GameObject endingFirstButton;
    // Start is called before the first frame update
    void Start()
    {
        SelectedButton(endingFirstButton);
    }

    public void ToEndingCutscene()
    {
        SceneManager.LoadScene(4);
    }

    public void PlaySelectSound()
    {
        SoundManager.PlaySound("MenuButton");
    }

    public void PlayHoverSound()
    {
        SoundManager.PlaySound("MenuButton_hover");
    }

    private void SelectedButton(GameObject firstSelected)
    {
        // clear selected button
        EventSystem.current.SetSelectedGameObject(null);
        // set a new selected button
        EventSystem.current.SetSelectedGameObject(firstSelected);
    }
}
