using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
  private static AudioManager _instance;
  public Sound[] sounds;
  private static Dictionary<string, float> soundTimerDictionary;

  public static AudioManager instance
  {
    get
    {
      return _instance;
    }
  }

  private void Awake()
  {
    if (_instance != null && _instance != this)
    {
      Destroy(this.gameObject);
    }
    else
    {
      _instance = this;
    }

    soundTimerDictionary = new Dictionary<string, float>();

    // foreach (Sound sound in sounds)
    // {
    //   sound.source = gameObject.AddComponent<AudioSource>();
    //   sound.source.clip = sound.clip;

    //   sound.source.volume = sound.volume;
    //   sound.source.pitch = sound.pitch;
    //   sound.source.loop = sound.isLoop;

    //   if (sound.hasCooldown)
    //   {
    //     Debug.Log(sound.name);
    //     soundTimerDictionary[sound.name] = sound.cooldown;
    //   }
    // }
  }

  private void Start()
  {
    // Add this part after having a theme song
    // Play('Theme');
  }
  public void Play(string name)
  {
    Sound sound = Array.Find(sounds, s => s.name == name);

    GameObject soundSource = new GameObject("Sound Source");
    AudioSource audioSource = soundSource.AddComponent<AudioSource>();
    sound.source = audioSource;
    sound.source.clip = sound.clip;
    sound.source.loop = sound.isLoop;

    Debug.Log("sound is played");

    if (sound.hasCooldown)
    {
        Debug.Log(sound.name);
        soundTimerDictionary[sound.name] = sound.cooldown;
    }

    if (sound == null)
    {
      Debug.LogError("Sound " + name + " Not Found!");
      return;
    }

    Debug.Log("sound is played");

    if (!CanPlaySound(sound))return;

    Debug.Log("sound is played");

    sound.source.Play();

    StartCoroutine(DestroySound(sound.source.clip, soundSource));
  }

  private IEnumerator DestroySound(AudioClip clip, GameObject soundSource)
  {
    yield return new WaitForSeconds(clip.length);
    Destroy(soundSource);
  }

  public void Stop(string name)
  {
    Sound sound = Array.Find(sounds, s => s.name == name);

    if (sound == null)
    {
      Debug.LogError("Sound " + name + " Not Found!");
      return;
    }

    sound.source.Stop();
  }

  private static bool CanPlaySound(Sound sound)
  {
    if (soundTimerDictionary.ContainsKey(sound.name))
    {
      float lastTimePlayed = soundTimerDictionary[sound.name];

      if (lastTimePlayed + sound.clip.length < Time.time)
      {
        soundTimerDictionary[sound.name] = Time.time;
        return true;
      }

      return false;
    }

    return true;
  }
}

