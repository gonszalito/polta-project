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
        // Cursor.visible = false;
        // Cursor.lockState = CursorLockMode.Locked;
        SelectedButton(mainFirstButton);



        ConfigureAudio();
  
        
    }

    public void ConfigureAudio()
    {
        if(!PlayerPrefs.HasKey("sfxVolume"))
        {
            PlayerPrefs.SetFloat("sfxVolume", 1f);
        }
        else
        {
            float sfxVolume = PlayerPrefs.GetFloat("sfxVolume");
            PlayerPrefs.SetFloat("sfxVolume",sfxVolume);
        }

        if(!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", 1f);
        }
        else
        {
            float musicVolume = PlayerPrefs.GetFloat("musicVolume");
            PlayerPrefs.SetFloat("musicVolume", musicVolume);
        }

    }

    public void PlayGame()
    {
        // Audio Implementation 1
        // FindObjectOfType<AudioManager>().Play("MenuButton");

        // Audio Implementation 2
        menuButton = GetComponent<Button>();
        Invoke("GetScene", 0.5f);
    }

    private void FixeUpdate() 
    {
        ConfigureAudio();  
      
    }

     public void OpenSettings()
    {
        mainMenuUI.SetActive(false);
        settingsMenuUI.SetActive(true);
        SelectedButton(settingsFirstButton);
    }

    public void BackSettings()
    {
        mainMenuUI.SetActive(true);
        settingsMenuUI.SetActive(false);
        SelectedButton(mainFirstButton);

    }

    public void OpenGallery()
    {
        mainMenuUI.SetActive(false);
        galleryMenuUI.SetActive(true);
        SelectedButton(galleryFirstButton);
    }

    public void BackGallery()
    {
        mainMenuUI.SetActive(true);
        galleryMenuUI.SetActive(false);
        SelectedButton(mainFirstButton);
    }

    public void OpenAbout()
    {
        mainMenuUI.SetActive(false);
        aboutMenuUI.SetActive(true);
        SelectedButton(aboutFirstButton);
    }

    public void BackAbout()
    {
        mainMenuUI.SetActive(true);
        aboutMenuUI.SetActive(false);
        SelectedButton(mainFirstButton);
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

    private void SelectedButton(GameObject firstSelected)
    {
        // clear selected button
        EventSystem.current.SetSelectedGameObject(null);
        // set a new selected button
        EventSystem.current.SetSelectedGameObject(firstSelected);
    }
}
