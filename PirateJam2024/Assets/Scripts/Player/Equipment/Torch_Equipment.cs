using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch_Equipment : Equipment_Base
{
    [SerializeField]
    float maxMP;
    [SerializeField]
    float mpGain;
    [SerializeField]
    float mpDrain;
    [SerializeField]
    HUDBar hUDBar;

    float currentMP;

    Light lightSource;

    AudioSource audioSource;

    protected override void Awake() {
        base.Awake();
        lightSource = GetComponent<Light>();
        audioSource = GetComponent<AudioSource>();
        currentMP = maxMP;
    }

    public override void ActivateObject()
    {
        ToggleLightSource();
    }

    protected override void Update() {
        if (currentMP <= 0) {
            lightSource.enabled = false;
        }
        UpdateMP();
    }

    public bool IsLightOn() {
        return lightSource.enabled;
    }

    private void UpdateMP() {
        if (lightSource.enabled) {
            currentMP -= Time.deltaTime * mpDrain;
        } else {
            currentMP += Time.deltaTime * mpGain;
        }
        currentMP = Mathf.Clamp(currentMP, 0, maxMP);
        hUDBar.SetBar(currentMP/maxMP);
    }
    
    private void ToggleLightSource(){
        lightSource.enabled = !lightSource.enabled;
        if (lightSource.enabled) {
            audioSource.Play();
        } else {
            audioSource.Stop();
        }
    }

    
}
