using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class MusicConfiguration : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    [SerializeField] AudioSource musicSource;

    // Start is called before the first frame update
    void Start()
    {
        if(!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", 1);
            Load();
        }
        else
        {
            Load();
        }
    }

    // Update is called once per frame
    public void ChangeVolume()
    {
        if(volumeSlider.value == 0)
        {
            musicSource.volume = 0;
        }
        else
        {
            musicSource.volume = PlayerPrefs.GetFloat("musicVolume");
        }
        // Debug.Log("slider" + volumeSlider.value);
        // Debug.Log("saved" + musicSource.volume);
        Save();
    }

    public void Load()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("musicVolume");
    }

    public void Save()
    {
        PlayerPrefs.SetFloat("musicVolume", volumeSlider.value);
    }
}
