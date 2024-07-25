using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    private float maxHP;
    [SerializeField]
    private Transform spawnPointParent;


    private float currentHP;

    private void Awake() {
        currentHP = maxHP;
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

    public void UpgradeMaxHP(float hpGained) {
        maxHP += hpGained;
        currentHP = maxHP;
    }

    private void ProcessDeath() {
        Debug.Log("Player died!");
    }
}
