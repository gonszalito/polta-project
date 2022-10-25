using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Events;


public class MainMenu : MonoBehaviour
{

    public AudioSource test;
    private Button menuButton;

    public void PlayGame()
    {
        // Audio Implementation 1
        // FindObjectOfType<AudioManager>().Play("MenuButton");

        // Audio Implementation 2
        menuButton = GetComponent<Button>();
        SoundManager.PlaySound("MenuButton");

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
        Time.timeScale = 1f;
    }

    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }
}
