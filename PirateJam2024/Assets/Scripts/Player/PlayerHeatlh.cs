using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerStats))]
public class PlayerHeatlh : MonoBehaviour
{
    PlayerStats stats;
    private float currentHP;

    private void Awake() {
        stats = GetComponent<PlayerStats>();
        maxHP = currentHP;
    }

    public void TakeDamage(float damage){
        currentHP -= damage;
        if (currentHP <= 0) {
            ProcessDeath();
        }
    }

    public void Heal(float hpRegained){
        if (currentHP > 0) {
            currentHP += hpRegained;
            Mathf.Clamp(currentHP, 0, maxHP);
        }
    }

    private void ProcessDeath() {
        Debug.Log("Player died!");
    }
}
