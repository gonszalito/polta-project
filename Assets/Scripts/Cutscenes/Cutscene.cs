using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class Cutscene : MonoBehaviour
{
    VideoPlayer videoPlayer;
    private double videoLength;
    // Start is called before the first frame update
    void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();
        videoLength = videoPlayer.clip.length;
    }

    // Update is called once per frame
    void Update()
    {
        if(videoPlayer.clip.name == "Opening")
        {
            Invoke("GetStarted", ((float)videoLength));
        }
        else if(videoPlayer.clip.name == "Ending")
        {
            Invoke("BackToMainMenu", ((float)videoLength));
        }
        else
        {
            Debug.Log("ERROR: VIDEO NAME NOT FOUND.");
        }
    }

    void GetStarted()
    {
        SceneManager.LoadScene(2);
    }

    void BackToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
