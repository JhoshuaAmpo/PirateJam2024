using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySoundMaker : MonoBehaviour
{
    [SerializeField]
    AudioClip attackSFX;
    [SerializeField]
    AudioClip takeDamageSFX;
    [SerializeField]
    AudioClip moveSFX;
    AudioSource audioSource;

    bool IsPlayingLoopedClip = false;

    private void Awake() {
        audioSource = GetComponent<AudioSource>();
    }
    
    public void PlayMove() {
        PlaySFXLoop(moveSFX);
    }

    public void PlayTakeDamage() {
        PlaySFXOnce(takeDamageSFX);
    }

    public void PlayAttack() {
        PlaySFXOnce(attackSFX);
    }

    private void PlaySFXOnce(AudioClip ac) {
        audioSource.Stop();
        audioSource.PlayOneShot(ac);
         IsPlayingLoopedClip = false;
    }

    private void PlaySFXOnce(AudioClip ac, float volume) {
        audioSource.Stop();
        audioSource.PlayOneShot(ac, volume);
         IsPlayingLoopedClip = false;
    }

    private void PlaySFXLoop(AudioClip ac) {
        if (IsPlayingLoopedClip) { return; }
        audioSource.Stop();
        audioSource.loop = true;
        audioSource.clip = ac;
        audioSource.Play();
        IsPlayingLoopedClip = true;
    }

    private void PlaySFXLoop(AudioClip ac, float volume) {
        if (IsPlayingLoopedClip) { return; }
        audioSource.Stop();
        audioSource.volume = volume;
        audioSource.loop = true;
        audioSource.clip = ac;
        audioSource.Play();
        IsPlayingLoopedClip = true;
    }
}
