using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throwable_Equipment : Equipment_Base
{
    [SerializeField]
    float projectileForce;
    Rigidbody rb;

    Vector3 originalPos;

    private void Awake() {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        originalPos = transform.position;
    }

    public override void ActivateObject()
    {
        Debug.Log("Using Throw Object!");
        rb.useGravity = true;
        Vector3 force = (transform.forward + transform.up).normalized * projectileForce;
        rb.AddForce(force, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision other) {
        Debug.Log("Succesfully hit: " + other.gameObject.name);
        rb.velocity = Vector3.zero;
        transform.SetPositionAndRotation(originalPos, Quaternion.identity);
        rb.useGravity = false;
    }
}
