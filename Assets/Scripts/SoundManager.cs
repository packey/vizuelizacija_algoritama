using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    public static SoundManager instance;

    [Header("Audio")]
    public AudioClip clickSound;
    public AudioClip bgMusic;

    public AudioSource musicSource;
    public AudioSource soundSource; 

	// Use this for initialization
	void Start () {

        if (instance == null)
            instance = this;
        else
            DontDestroyOnLoad(instance);
	}
	
	
    /// <summary>
    /// Play sound effect
    /// </summary>
    /// <param name="soundClip"></param>
    public void PlaySound(AudioClip soundClip)
    {
        soundSource.PlayOneShot(soundClip);
    }

    /// <summary>
    /// Play background music
    /// </summary>
    /// <param name="musicClip"></param>
    public void PlayMusic(AudioClip musicClip)
    {
        if (musicClip)
        {
            musicSource.clip = musicClip;
            musicSource.Play();
        }        
    }
}
