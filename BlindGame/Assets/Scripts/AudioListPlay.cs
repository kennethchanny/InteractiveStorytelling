using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioListPlay : MonoBehaviour
{
    public AudioSource[] audioSourceRefs;


    public void PlayAudio(int index)
    {
        {
            // Check if the provided index is within the valid range
            if (index >= 0 && index < audioSourceRefs.Length)
            {
                // Play the audio clip
                audioSourceRefs[index].Play();
            }
            else
            {
                Debug.LogError("Invalid audiosourcerefs index: " + index);
            }
        }
    }
}
