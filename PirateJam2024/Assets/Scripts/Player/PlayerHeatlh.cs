using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHeatlh : MonoBehaviour
{
    [SerializeField]
    private float maxHP;
    private float currentHP;

    private void Awake() {
        maxHP = currentHP;
    }

    private void ProcessDeath() {
        Debug.Log("Player died!");
    }
}
