using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowWall : MonoBehaviour
{
    PlayerHands playerHands;

    private void Awake() {
        playerHands = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHands>();
    }
    private void OnTriggerEnter(Collider other) {
        if (playerHands.IsLightOn()) { 
            Debug.Log("Torch is out!");
        }
        if (other.CompareTag("Player") && !playerHands.IsLightOn()) {
            other.GetComponent<PlayerHealth>().TakeDamage(100000);
        } 
    }
}
