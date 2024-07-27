using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throwable_Equipment : Equipment_Base
{
    [SerializeField]
    float projectileForce;
    
    [SerializeField]
    GameObject projectile;
    
    Rigidbody projectileRb;
    Transform rootT;

    

    protected override void Awake() {
        // base.Awake();
        projectileRb = projectile.GetComponent<Rigidbody>();
        projectileRb.useGravity = false;
        rootT = transform.root;
    }

    public override void ActivateObject()
    {
        Debug.Log("Using Throw Object!");
        projectile.transform.position = transform.position;
        projectile.SetActive(true);
        projectile.GetComponent<Throwable_Behavior>().ReadyPotion();
        Vector3 force = (rootT.forward + rootT.up).normalized * projectileForce;
        projectileRb.AddForce(force, ForceMode.Impulse);
        projectileRb.useGravity = true;
    }

    // private void OnCollisionEnter(Collision other) {
    //     Debug.Log("Succesfully hit: " + other.gameObject.name);
    //     projectile.SetActive(false);
    //     projectileRb.velocity = Vector3.zero;
    //     projectileRb.angularVelocity = Vector3.zero;
    //     projectileRb.useGravity = false;
    // }
}
