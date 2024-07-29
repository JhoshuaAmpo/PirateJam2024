using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStrikeZone : MonoBehaviour
{
    public bool IsPlayerInStrikeZone {get; private set;} = false;

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            IsPlayerInStrikeZone = true;
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.CompareTag("Player")) {
            IsPlayerInStrikeZone = false;
        }
    }
}
