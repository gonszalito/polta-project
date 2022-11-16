using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundAssets : MonoBehaviour
{
    private static SoundAssets _soundAssets;

    public static SoundAssets soundAssets
    {
        get 
        {
            if (_soundAssets == null) _soundAssets = Instantiate(Resources.Load<SoundAssets>("SoundAssets"));
            return _soundAssets;
        }
    }

    public SoundAudioClip[] soundAudioClipArray;

    [System.Serializable]
    public class SoundAudioClip
    {
        // public SoundManager.Sound sound;
        public string soundName;
        public AudioClip audioClip;
        public float timeDelay= 0f;
        public bool isLoop = false;
        public float volume = 0.1f;
        public bool isDestroy = false;


        [HideInInspector] public float lastTimePlayed;
        
        public void DestroyTrue()
        {
            isDestroy = true;
        }

        public bool CanPlay()
        {

            if(audioClip.length + timeDelay < Time.time)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public float GetTimeDelay()
        {
            return this.audioClip.length;
        }
    }

    private void Awake()
    {
        SoundManager.Initialize();
    }

    // public bool CanPlay(SoundAudioClip soundAudioClip)
    // {
    //       if(soundAudioClip.lastTimePlayed + soundAudioClip.timeDelay < Time.time)
    //       {
    //         return true;
    //       }
    //       else
    //       {
    //         return false;
    //       }
    // }

}
