using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SoundManager 
{

    public enum Sound
    {
        MenuButton,
        Walking,
    } 

    private static Dictionary<string, float> soundTimerDictionary;

    public static void Initialize()
    {
        soundTimerDictionary = new Dictionary<string, float>();
        soundTimerDictionary["MenuButton"] = 0.5f;
        soundTimerDictionary["Walking"] = 1f;
    }

    private static bool CanPlaySound(string soundName)
    {
        switch (soundName)
        {
            default:
                return true;
            case "MenuButton":
            Debug.Log(soundName);
            Debug.Log(soundTimerDictionary.ContainsKey(soundName));
                if (soundTimerDictionary.ContainsKey(soundName))
                {
                    float lastTimePlayed = soundTimerDictionary[soundName];
                    float playerMoveTimerMax = .05f;
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
            case "Walking":
                Debug.Log(soundTimerDictionary.ContainsKey(soundName));
                if (soundTimerDictionary.ContainsKey(soundName))
                {
                    float lastTimePlayed = soundTimerDictionary[soundName];
                    float playerMoveTimerMax = 1f;
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

                // break;
        }
    }


    #region PlaySound Variants
    public static void PlaySound(Sound sound) 
    {
        GameObject soundGameObject = new GameObject("Sound");
        AudioSource audioSource = soundGameObject.AddComponent<AudioSource>();
        audioSource.PlayOneShot(GetAudioClip(sound));
    }

       public static void PlaySound(string soundName) 
    {
        if (CanPlaySound(soundName))
        {   
            Debug.Log(soundName + "this");
            GameObject soundGameObject = new GameObject("Sound");
            AudioSource audioSource = soundGameObject.AddComponent<AudioSource>();
            audioSource.PlayOneShot(GetAudioClip(soundName));
             Debug.Log(audioSource + "this");
        }
    }
    #endregion 
    
    #region GetAudioClip Variants
    // Try different methods to fetch the sound
      private static AudioClip GetAudioClip(Sound sound)
    {
        foreach(SoundAssets.SoundAudioClip soundAudioClips in SoundAssets.soundAssets.soundAudioClipArray)
        {
            if (soundAudioClips.sound == sound)
            {
                return soundAudioClips.audioClip;
            }
        } 

        Debug.LogError("Sound" + sound + "not found");
        return null;

    }

    private static AudioClip GetAudioClip(string soundName)
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
    #endregion


     
    private static SoundAssets.SoundAudioClip GetSoundAudioClip(string soundName)
    {
        foreach(SoundAssets.SoundAudioClip soundAudioClips in SoundAssets.soundAssets.soundAudioClipArray)
        {
            if (soundAudioClips.soundName == soundName)
            {
                return soundAudioClips;
            }
        }  
        return null;
    }

}
