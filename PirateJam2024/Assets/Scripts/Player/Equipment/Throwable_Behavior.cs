using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class Throwable_Behavior : MonoBehaviour
{
    SphereCollider potionCollider;
    SphereCollider explosionCollider;
    MeshRenderer meshRenderer;
    Rigidbody rb;

    private void Awake() {
        List<SphereCollider> scList = new();
        meshRenderer = GetComponent<MeshRenderer>();
        GetComponentsInChildren<SphereCollider>(scList);
        potionCollider = scList[0];
        explosionCollider = scList[1];
        explosionCollider.enabled = false;
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision other) {
        ProcessExplosion();
    }

    public void ProcessExplosion() {
        ToggleComponents();
        meshRenderer.enabled = false;
        Debug.Log("Explosion!");
    }

    public void ReadyPotion(){
        meshRenderer.enabled = true;
        potionCollider.enabled = true;
        explosionCollider.enabled = false;
    }

    public void ToggleComponents() {
        potionCollider.enabled = !potionCollider.enabled;
        explosionCollider.enabled = !explosionCollider.enabled;
    }
}
