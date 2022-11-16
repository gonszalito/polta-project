using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

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
        soundTimerDictionary["Walking"] = 0f;
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
                    float playerMoveTimerMax = 0.4f;
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
    // public static void PlaySound(Sound sound) 
    // {
    //     GameObject soundGameObject = new GameObject("Sound");
    //     AudioSource audioSource = soundGameObject.AddComponent<AudioSource>();
    //     audioSource.volume = GetVolume(sound);
    //     audioSource.PlayOneShot(GetAudioClip(sound));
    // }

       public static void PlaySound(string soundName) 
    {
        if (CanPlaySound(soundName))
        {   
            Debug.Log(soundName + "this");
            GameObject soundGameObject = new GameObject("Sound");
            AudioSource audioSource = soundGameObject.AddComponent<AudioSource>();
            SoundAssets.SoundAudioClip soundAudioClip = GetSoundAudioClip(soundName);
            audioSource.volume = GetVolume(soundName) * PlayerPrefs.GetFloat("sfxVolume");
            Debug.Log(soundName + audioSource.volume);
            audioSource.PlayOneShot(GetAudioClip(soundName));
            Debug.Log(audioSource + "this");
            Debug.Log("sfx volume" + PlayerPrefs.GetFloat("sfxVolume"));
            Debug.Log("Volume" + audioSource.volume);

            corout newInstance = new corout();
            newInstance.DestroySound(GetAudioClip(soundName),soundAudioClip);

            if (soundAudioClip.isDestroy)
            {
                UnityEngine.Object.Destroy(soundGameObject);
            }

        }


    }
    #endregion 

    // private static IEnumerator DestroySound(AudioClip clip, GameObject soundSource)
    // {
    //     yield return new WaitForSeconds(clip.length);
    //     Destroy(soundSource);
    // }

    class corout 
    { 
        public IEnumerator DestroySound(AudioClip clip, SoundAssets.SoundAudioClip soundName)
        {
            yield return new WaitForSeconds(clip.length+1f);
            soundName.DestroyTrue();
        }   
    }
 
    
    
    #region GetAudioClip Variants
    // // Try different methods to fetch the sound
    //   private static AudioClip GetAudioClip(Sound sound)
    // {
    //     foreach(SoundAssets.SoundAudioClip soundAudioClips in SoundAssets.soundAssets.soundAudioClipArray)
    //     {
    //         if (soundAudioClips.sound == sound)
    //         {
    //             return soundAudioClips.audioClip;
    //         }
    //     } 

    //     Debug.LogError("Sound" + sound + "not found");
    //     return null;

    // }

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
    
    public static void PlaySound(string soundName, Vector3 position)
    {
        if (CanPlaySound(soundName))
        {
            GameObject soundGameObject = new GameObject("Sound");
            soundGameObject.transform.position = position;
            AudioSource audioSource = soundGameObject.AddComponent<AudioSource>();
            audioSource.clip = GetAudioClip(soundName);
            audioSource.Play();
        }
    }

    public static void SetButtonSound(string soundName,Button button)
    {
        Button btn = button.GetComponent<Button>();
        UnityAction buttonAction = null;
        buttonAction += () => SoundManager.PlaySound(soundName);
        btn.onClick.AddListener(buttonAction);  
    }

    // private static float GetVolume(Sound sound)
    // {
    //     foreach(SoundAssets.SoundAudioClip soundAudioClips in SoundAssets.soundAssets.soundAudioClipArray)
    //     {
    //         if (soundAudioClips.sound == sound)
    //         {
    //             return soundAudioClips.volume;
    //         }
    //     } 

    //     Debug.LogError("String" + sound + "not found");
    //     return 0.3f;

    // }

    //    private static SoundAudioClip GetSoundAudioClip(string soundName)
    // {
    //     foreach(SoundAssets.SoundAudioClip soundAudioClips in SoundAssets.soundAssets.soundAudioClipArray)
    //     {
    //         if (soundAudioClips.soundName == soundName)
    //         {
    //             return soundAudioClips;
    //         }
    //     } 

    //     Debug.LogError("String" + sound + "not found");
    //     return 0.3f;

    // }

    private static float GetVolume(string soundName)
    {
        foreach(SoundAssets.SoundAudioClip soundAudioClips in SoundAssets.soundAssets.soundAudioClipArray)
        {
            if (soundAudioClips.soundName == soundName)
            {
                return soundAudioClips.volume;
            }
        } 

        Debug.LogError("String" + soundName + "not found");
        return 0.3f;

    }

}
