using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;
    public static bool journalIsOpen = false;
    public GameObject pauseMenuUI;
    public GameObject journalMenuUI;
    [SerializeField] AudioSource audioSource;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused && journalIsOpen == false)
            {
                Resume();
            } 
            else if (gameIsPaused && journalIsOpen)
            {
                ResumeThroughJournal();
            } else
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
    }

    public void BackJournal()
    {
        pauseMenuUI.SetActive(true);
        journalMenuUI.SetActive(false);
        journalIsOpen = false;
    }
    public void ResumeThroughJournal()
    {
        journalMenuUI.SetActive(false);
        Time.timeScale = 1f;
        journalIsOpen = false;
        gameIsPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        // Time.timeScale = 0f;
        gameIsPaused = true;
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    public void LoadMenu()
    {
        Debug.Log("MAIN MENU");
        gameIsPaused = false;
        SceneManager.LoadScene(0);

    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void PlaySound()
    {
        SoundManager.PlaySound("MenuButton");
    }
}
