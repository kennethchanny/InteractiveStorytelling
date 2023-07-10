using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioFade : MonoBehaviour
{
    public AudioMixerSnapshot fadeInSnapshot;
    public AudioMixerSnapshot fadeOutSnapshot;
    public float fadeDuration = 1.0f;

    private AudioSource audioSource;
    private AudioClip audioClip;

    private float fadeTimer = 0.0f;
    private float buffer = 2.5f;
    private bool isPlaying = false;

    public bool playOnStart = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioClip == null)
            audioClip = GetComponent<AudioSource>().clip;


        if (playOnStart)
        {
            FadeIn();
        }
        
     
    }

    private void Update()
    {
        if (isPlaying)
        {
            fadeTimer += Time.deltaTime;
            if (fadeTimer >= audioClip.length - buffer)
            {
                FadeOut();
            }
        }   
    }

    public void FadeOut()
    {
        fadeOutSnapshot.TransitionTo(fadeDuration);
        isPlaying= false;
    }

    public void FadeIn()
    {
        fadeInSnapshot.TransitionTo(fadeDuration);
        isPlaying = true;
    }
}
