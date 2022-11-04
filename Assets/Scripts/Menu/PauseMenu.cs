using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;
    public static bool journalIsOpen = false;
    public static bool settingsIsOpen = false;
    public GameObject pauseMenuUI;
    public GameObject journalMenuUI;
    public GameObject settingsMenuUI;
    public GameObject pauseFirstButton, journalFirstButton, settingsFirstButton;
    [SerializeField] AudioSource audioSource;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused && !journalIsOpen && !settingsIsOpen)
            {
                Resume();
            } 
            else if (gameIsPaused && journalIsOpen && !settingsIsOpen)
            {
                ResumeThroughJournal();
            }
            else if (gameIsPaused && settingsIsOpen && !journalIsOpen)
            {
                ResumeThroughSettings();
            } 
            else
            {
                Pause();
                audioSource.Play();
            }
        }
    }
    public void OpenJournal()
    {
        pauseMenuUI.SetActive(false);
        journalMenuUI.SetActive(true);
        journalIsOpen = true;
        // clear selected button
        EventSystem.current.SetSelectedGameObject(null);
        // set a new selected button
        EventSystem.current.SetSelectedGameObject(journalFirstButton);
    }

    public void OpenSettings()
    {
        pauseMenuUI.SetActive(false);
        settingsMenuUI.SetActive(true);
        settingsIsOpen = true;
        // clear selected button
        EventSystem.current.SetSelectedGameObject(null);
        // set a new selected button
        EventSystem.current.SetSelectedGameObject(settingsFirstButton);
        Debug.Log("OPEN SETTINGS");
    }

    public void BackJournal()
    {
        pauseMenuUI.SetActive(true);
        journalMenuUI.SetActive(false);
        journalIsOpen = false;
        // clear selected button
        EventSystem.current.SetSelectedGameObject(null);
        // set a new selected button
        EventSystem.current.SetSelectedGameObject(pauseFirstButton);
    }

    public void BackSettings()
    {
        pauseMenuUI.SetActive(true);
        settingsMenuUI.SetActive(false);
        settingsIsOpen = false;
        // clear selected button
        EventSystem.current.SetSelectedGameObject(null);
        // set a new selected button
        EventSystem.current.SetSelectedGameObject(pauseFirstButton);
    }

    void ResumeThroughJournal()
    {
        journalMenuUI.SetActive(false);
        Time.timeScale = 1f;
        journalIsOpen = false;
        gameIsPaused = false;
        Debug.Log("THROUGH JOURNAL");
    }

    void ResumeThroughSettings()
    {
        settingsMenuUI.SetActive(false);
        Time.timeScale = 1f;
        settingsIsOpen = false;
        gameIsPaused = false;
        Debug.Log("THROUGH SETTINGS");
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
        // clear selected button
        EventSystem.current.SetSelectedGameObject(null);
        // set a new selected button
        EventSystem.current.SetSelectedGameObject(pauseFirstButton);
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
        Debug.Log("RESUME");
    }

    public void LoadMenu()
    {
        Debug.Log("MAIN MENU");
        gameIsPaused = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);

    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void PlaySelectSound()
    {
        SoundManager.PlaySound("MenuButton");
    }

    public void PlayHoverSound()
    {
        SoundManager.PlaySound("MenuButton_hover");
    }
}
