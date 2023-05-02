using FPHunter.Enum;
using FPHunter.GenericSingleton;
using System;
using UnityEngine;

namespace FPHunter.Managers
{
    public class SoundManager : GenericSingleton<SoundManager>
    {
        [SerializeField] private AudioSource SoundEffect;
        [SerializeField] private AudioSource SoundMusic;

        [SerializeField] private SoundType[] Sounds;

        public void PlayEffects(Sounds sound)
        {
            AudioClip clip = GetAudioClip(sound);
            if (clip != null)
            {
                SoundEffect.PlayOneShot(clip);
            }
        }

        public void PlayMusic(Sounds sound)
        {
            AudioClip clip = GetAudioClip(sound);
            if (clip != null)
            {
                SoundMusic.clip = clip;
                SoundMusic.Play();
            }
        }

        public void StopMusic(Sounds sound)
        {
            AudioClip clip = GetAudioClip(sound);
            if (clip != null)
            {
                SoundMusic.clip = clip;
                SoundMusic.Stop();
            }
        }

        private AudioClip GetAudioClip(Sounds sound)
        {
            SoundType item = Array.Find(Sounds, i => i.soundType == sound);
            if (item != null)
            {
                return item.soundClip;
            }
            else
            {
                return null;
            }
        }
    }

    [Serializable]
    public class SoundType
    {
        public Sounds soundType;
        public AudioClip soundClip;
    }
}