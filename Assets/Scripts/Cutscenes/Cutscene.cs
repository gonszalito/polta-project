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
        Invoke("GetStarted", ((float)videoLength));
    }

    void GetStarted()
    {
        SceneManager.LoadScene(2);
    }
}
