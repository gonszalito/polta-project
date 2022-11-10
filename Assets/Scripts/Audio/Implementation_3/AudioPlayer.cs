using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    private static AudioPlayer instance;

    private Dictionary<string, float> soundTimerDictionary;

    private void Awake() 
    {   
        if (instance != null)
        {
            Debug.LogWarning("Found more than one Audio Player in the scene");
        }
        instance = this;
    }


    private void Start()
    {
        soundTimerDictionary = new Dictionary<string, float>();
        foreach(SoundAssets.SoundAudioClip soundAudioClip in SoundAssets.soundAssets.soundAudioClipArray)
        {
            GameObject soundGameObject = new GameObject(soundAudioClip.soundName);
            AudioSource audioSource = soundGameObject.AddComponent<AudioSource>();
            audioSource.volume = soundAudioClip.volume;
            audioSource.loop = soundAudioClip.isLoop;
            audioSource.clip = soundAudioClip.audioClip;
            audioSource.enabled = true;
            this.soundTimerDictionary.Add(soundAudioClip.soundName, soundAudioClip.timeDelay);
        }
    }

    public static AudioPlayer GetInstance() 
    {
        return instance;
    }

    private bool CanPlaySound(string soundName)
    {
        if (soundTimerDictionary.ContainsKey(soundName))
        {
            float lastTimePlayed = soundTimerDictionary[soundName];
            float playerMoveTimerMax = .3f;
            if (lastTimePlayed + playerMoveTimerMax < Time.time)
            {
                soundTimerDictionary[soundName] = Time.time;
                return true;
            } 
            else 
            {
                return false;
            }
        }
        else 
        {
            return true;
        }
    }


    public void PlaySound(string soundName) 
    {
        if (CanPlaySound(soundName))
        {
            GameObject audioPlayer = GameObject.Find(soundName);
            AudioSource audio = audioPlayer.GetComponent<AudioSource>();
            audio.PlayOneShot(audio.clip,audio.volume);
        }   
    }

    private AudioClip GetAudioClip(string soundName)
    {
        foreach(SoundAssets.SoundAudioClip soundAudioClips in SoundAssets.soundAssets.soundAudioClipArray)
        {
            if (soundAudioClips.soundName == soundName)
            {
                return soundAudioClips.audioClip;
            }
        } 

        Debug.LogError("String" + soundName + "not found");
        return null;
    }


}
