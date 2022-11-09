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
                PlayPauseAppearSound();
            }
        }
    }
    public void OpenJournal()
    {
        pauseMenuUI.SetActive(false);
        journalMenuUI.SetActive(true);
        journalIsOpen = true;
        SelectedButton(journalFirstButton);
    }

    public void OpenSettings()
    {
        pauseMenuUI.SetActive(false);
        settingsMenuUI.SetActive(true);
        settingsIsOpen = true;
        SelectedButton(settingsFirstButton);
    }

    public void BackJournal()
    {
        pauseMenuUI.SetActive(true);
        journalMenuUI.SetActive(false);
        journalIsOpen = false;
        SelectedButton(pauseFirstButton);
    }

    public void BackSettings()
    {
        pauseMenuUI.SetActive(true);
        settingsMenuUI.SetActive(false);
        settingsIsOpen = false;
        SelectedButton(pauseFirstButton);
    }

    void ResumeThroughJournal()
    {
        journalMenuUI.SetActive(false);
        Time.timeScale = 1f;
        journalIsOpen = false;
        gameIsPaused = false;
        PlayPauseClosedSound();
        Debug.Log("THROUGH JOURNAL");
    }

    void ResumeThroughSettings()
    {
        settingsMenuUI.SetActive(false);
        Time.timeScale = 1f;
        settingsIsOpen = false;
        gameIsPaused = false;
        PlayPauseClosedSound();
        Debug.Log("THROUGH SETTINGS");
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
        SelectedButton(pauseFirstButton);
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
        PlayPauseClosedSound();
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

    private void PlayPauseAppearSound()
    {
        SoundManager.PlaySound("PauseAppear");
    }

    private void PlayPauseClosedSound()
    {
        SoundManager.PlaySound("PauseClosed");
    }

    private void SelectedButton(GameObject firstSelected)
    {
        // clear selected button
        EventSystem.current.SetSelectedGameObject(null);
        // set a new selected button
        EventSystem.current.SetSelectedGameObject(firstSelected);
    }
}
