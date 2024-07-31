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

    float currentMP;

    Light lightSource;

    protected override void Awake() {
        base.Awake();
        lightSource = GetComponent<Light>();
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
    }
    
    private void ToggleLightSource(){
        lightSource.enabled = !lightSource.enabled;
    }

    
}
