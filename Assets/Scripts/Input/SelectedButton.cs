using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SelectedButton : MonoBehaviour
{
    public GameObject mainMenuUI, settingsMenuUI, galleryMenuUI, aboutMenuUI;
    public GameObject mainFirstButton, settingsFirstButton, galleryFirstButton, aboutFirstButton;
    Button primaryButton;
    // Start is called before the first frame update
    void Start()
    {
        // clear selected button
        EventSystem.current.SetSelectedGameObject(null);
        // set a new selected button
        EventSystem.current.SetSelectedGameObject(mainFirstButton);
    }

    public void OpenSettings()
    {
        mainMenuUI.SetActive(false);
        settingsMenuUI.SetActive(true);
         // clear selected button
        EventSystem.current.SetSelectedGameObject(null);
        // set a new selected button
        EventSystem.current.SetSelectedGameObject(settingsFirstButton);
    }

    public void BackSettings()
    {
        mainMenuUI.SetActive(true);
        settingsMenuUI.SetActive(false);
         // clear selected button
        EventSystem.current.SetSelectedGameObject(null);
        // set a new selected button
        EventSystem.current.SetSelectedGameObject(mainFirstButton);
    }

    public void OpenGallery()
    {
        mainMenuUI.SetActive(false);
        galleryMenuUI.SetActive(true);
         // clear selected button
        EventSystem.current.SetSelectedGameObject(null);
        // set a new selected button
        EventSystem.current.SetSelectedGameObject(galleryFirstButton);
    }

    public void BackGallery()
    {
        mainMenuUI.SetActive(true);
        galleryMenuUI.SetActive(false);
         // clear selected button
        EventSystem.current.SetSelectedGameObject(null);
        // set a new selected button
        EventSystem.current.SetSelectedGameObject(mainFirstButton);

    }

    public void OpenAbout()
    {
        mainMenuUI.SetActive(false);
        aboutMenuUI.SetActive(true);
         // clear selected button
        EventSystem.current.SetSelectedGameObject(null);
        // set a new selected button
        EventSystem.current.SetSelectedGameObject(aboutFirstButton);
    }

    public void BackAbout()
    {
        mainMenuUI.SetActive(true);
        aboutMenuUI.SetActive(false);
         // clear selected button
        EventSystem.current.SetSelectedGameObject(null);
        // set a new selected button
        EventSystem.current.SetSelectedGameObject(mainFirstButton);
    }
}
