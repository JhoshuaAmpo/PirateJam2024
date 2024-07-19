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

    public void TakeDamage(float damage){
        maxHP -= damage;
        if (maxHP <= 0) {
            ProcessDeath();
        }
    }

    private void ProcessDeath() {
        Debug.Log("Player died!");
    }
}
