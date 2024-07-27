using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throwable_Behavior : MonoBehaviour
{
    SphereCollider potionCollider;
    SphereCollider explosionCollider;
    MeshRenderer meshRenderer;

    private Action<bool> finishExploding;

    private void Awake() {
        List<SphereCollider> scList = new();
        meshRenderer = GetComponent<MeshRenderer>();
        GetComponentsInChildren<SphereCollider>(scList);
        potionCollider = scList[0];
        explosionCollider = scList[1];
        explosionCollider.enabled = false;
    }

    private void OnCollisionEnter(Collision other) {
        ToggleComponents();
        Debug.Log("This potion has hit something!");
    }

    public void ReadyPotion(){
        meshRenderer.enabled = true;
        potionCollider.enabled = true;
        explosionCollider.enabled = false;
    }

    private void ToggleComponents() {
        meshRenderer.enabled = !meshRenderer.enabled;
        potionCollider.enabled = !potionCollider.enabled;
        explosionCollider.enabled = !explosionCollider.enabled;
    }
}
