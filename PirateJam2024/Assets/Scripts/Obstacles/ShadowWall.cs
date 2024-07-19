using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowWall : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")/* and player light not held*/) {
            other.GetComponent<PlayerHeatlh>().TakeDamage(100000);
        } 
    }
}
