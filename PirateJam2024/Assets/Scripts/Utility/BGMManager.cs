using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMManager : MonoBehaviour
{
    List<AudioClip> audioClips;
    AudioSource audioSource;

    private void Awake() {
        audioClips = new List<AudioClip>();
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayClip(AudioClip clip) {
        audioSource.Stop();
        audioSource.clip = clip;
        audioSource.Play();
    }

    // private void Update()
    // {
    //     PlayWhenClipEnds();
    // }

    // private void PlayWhenClipEnds()
    // {
    //     if (audioClips.Count > 0)
    //     {
    //         audioSource.loop = false;
    //         if (!audioSource.isPlaying)
    //         {
    //             audioSource.clip = audioClips[0];
    //             audioClips.Remove(audioClips[0]);
    //             audioSource.Play();
    //             if (audioClips.Count == 0)
    //             {
    //                 audioSource.loop = true;
    //             }
    //         }
    //     }
    // }

    // public void AddToQueue(AudioClip clip) {
    //     audioClips.Add(clip);
    //     audioSource.loop = false;
    // }
}
