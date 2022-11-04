using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class MainMenu : MonoBehaviour
{
    public GameObject mainMenuUI, settingsMenuUI, galleryMenuUI, aboutMenuUI;
    public GameObject mainFirstButton, settingsFirstButton, galleryFirstButton, aboutFirstButton;
    public AudioSource test;
    private Button menuButton;
    [SerializeField] string hoverSound;

    void Start()
    {
        // clear selected button
        EventSystem.current.SetSelectedGameObject(null);
        // set a new selected button
        EventSystem.current.SetSelectedGameObject(mainFirstButton);
    }
    public void PlayGame()
    {
        // Audio Implementation 1
        // FindObjectOfType<AudioManager>().Play("MenuButton");

        // Audio Implementation 2
        menuButton = GetComponent<Button>();
        Invoke("GetScene", 0.5f);
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

    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }

    public void PlaySound()
    {
        SoundManager.PlaySound("MenuButton");
    }

    public void PlayHoverSound()
    {
        SoundManager.PlaySound(hoverSound);
    }

    void GetScene()
    {
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
    }
}
