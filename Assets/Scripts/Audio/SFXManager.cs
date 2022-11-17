using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = PlayerPrefs.GetFloat("sfxVolume");
    }

    private void Update() {
        audioSource.volume = PlayerPrefs.GetFloat("sfxVolume");
    }
}
