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
    public static bool mainMenuConfirmationIsOpen = false;
    public static bool quitConfirmationIsOpen = false;
    public GameObject pauseMenuUI;
    public GameObject journalMenuUI;
    public GameObject settingsMenuUI;
    public GameObject mainMenuConfirmationUI, quitConfirmationUI;
    public GameObject pauseFirstButton, journalFirstButton, 
    settingsFirstButton, mainMenuConfirmationFirstButton, 
    quitConfirmationFirstButton;

    public bool pauseIsOn { get; private set; }

    private static PauseMenu instance;

    public static PauseMenu GetInstance() 
    {
        return instance;
    }

    private void Awake() 
    {
        if (instance != null)
        {
            Debug.LogWarning("Found more than one Pause Menu in the scene");
        }
        instance = this;
    }
    
    void Update()
    {
        if (InputManager.GetInstance().GetPausePressed() == true && !DialogueManager.GetInstance().dialogueIsPlaying)
        {
            pauseIsOn = true;
            if (gameIsPaused && !journalIsOpen && !settingsIsOpen
            && !mainMenuConfirmationIsOpen && !quitConfirmationIsOpen)
            {
                Resume();
            } 
            else if (gameIsPaused && journalIsOpen && !settingsIsOpen 
            && !mainMenuConfirmationIsOpen && !quitConfirmationIsOpen)
            {
                ResumeThroughJournal();
            }
            else if (gameIsPaused && settingsIsOpen && !journalIsOpen
            && !mainMenuConfirmationIsOpen && !quitConfirmationIsOpen)
            {
                ResumeThroughSettings();
            } 
            else if (gameIsPaused && mainMenuConfirmationIsOpen 
            && !settingsIsOpen && !journalIsOpen && !quitConfirmationIsOpen)
            {
                ResumeThroughMainMenuConfirmation();
            }
            else if (gameIsPaused && quitConfirmationIsOpen && !settingsIsOpen 
            && !journalIsOpen && !mainMenuConfirmationIsOpen)
            {
                ResumeThroughQuitConfirmation();
            }
            else
            {
                Pause();
                PlayPauseAppearSound();
            }
        }
        else if(pauseIsOn == true)
        {
            StartCoroutine(WaitForPause(pauseIsOn));
        }
    }

    private IEnumerator WaitForPause(bool pauseIsOn) 
    {
        if (pauseIsOn)
        {
            yield return new WaitForSeconds(0.1f);
            // yield return new WaitForFixedUpdate();
            Debug.Log("waiting");
            this.pauseIsOn = false;
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

    public void OpenMainMenuConfirmation()
    {
        pauseMenuUI.SetActive(false);
        mainMenuConfirmationUI.SetActive(true);
        mainMenuConfirmationIsOpen = true;
        SelectedButton(mainMenuConfirmationFirstButton);
    }

    public void OpenQuitConfirmation()
    {
        pauseMenuUI.SetActive(false);
        quitConfirmationUI.SetActive(true);
        quitConfirmationIsOpen = true;
        SelectedButton(quitConfirmationFirstButton);
    }

    public void backMainMenuConfirmation()
    {
        pauseMenuUI.SetActive(true);
        mainMenuConfirmationUI.SetActive(false);
        mainMenuConfirmationIsOpen = false;
        SelectedButton(pauseFirstButton);
    }

    public void backQuitConfirmation()
    {
        pauseMenuUI.SetActive(true);
        quitConfirmationUI.SetActive(false);
        quitConfirmationIsOpen = false;
        SelectedButton(pauseFirstButton);
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

    void ResumeThroughMainMenuConfirmation()
    {
        mainMenuConfirmationUI.SetActive(false);
        Time.timeScale = 1f;
        mainMenuConfirmationIsOpen = false;
        gameIsPaused = false;
        PlayPauseClosedSound();
        Debug.Log("THROUGH MAIN MENU CONFIRMATION");
    }

    void ResumeThroughQuitConfirmation()
    {
        quitConfirmationUI.SetActive(false);
        Time.timeScale = 1f;
        quitConfirmationIsOpen = false;
        gameIsPaused = false;
        PlayPauseClosedSound();
        Debug.Log("THROUGH QUIT CONFIRMATION");
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
