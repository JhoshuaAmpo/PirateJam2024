using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throwable_Equipment : Equipment_Base
{
    [SerializeField]
    float projectileForce;
    // [SerializeField]
    // GameObject projectile;
    
    Rigidbody rb;
    Transform rootT;

    private void Awake() {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        rootT = transform.root;
    }

    public override void ActivateObject()
    {
        Debug.Log("Using Throw Object!");
        rb.useGravity = true;
        Vector3 force = (rootT.forward + rootT.up).normalized * projectileForce;
        rb.AddForce(force, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision other) {
        Debug.Log("Succesfully hit: " + other.gameObject.name);
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        transform.SetPositionAndRotation(transform.parent.position, Quaternion.identity);
        rb.useGravity = false;
    }
}
