using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SFXConfiguration : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    // [SerializeField] AudioSource musicSource;

    // Start is called before the first frame update
    void Start()
    {
        if(!PlayerPrefs.HasKey("sfxVolume"))
        {
            PlayerPrefs.SetFloat("sfxVolume", 1);
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
        // AudioListener.volume = volumeSlider.value;
        Save();
    }

    public void Load()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("sfxVolume");
    }

    public void Save()
    {
        PlayerPrefs.SetFloat("sfxVolume", volumeSlider.value);
    }
}
