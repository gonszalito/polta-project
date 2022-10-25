using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public AudioSource test;
    
    public void PlayGame()
    {
        // Audio Implementation 1
        // FindObjectOfType<AudioManager>().Play("MenuButton");

        // Audio Implementation 2
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
