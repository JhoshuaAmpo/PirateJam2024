
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Unity.VisualScripting;

public class EnemyHeath : MonoBehaviour
{
    [SerializeField]
    private float maxHealth = 100;

    private float currentHealth;
    // private xp

    // Start is called before the first frame update
    void Awake()
    {
        currentHealth = maxHealth;
        // getItem = GetComponent<itemdrop>();
    }

    // private void OnCollisionEnter(Collision other)
    // {
    //     if (other.gameObject.CompareTag ("player"))
    //     {
    //         TakeDamage(20);
    //     }
    // }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth < 0) {
            ProcessDeath();
        }
        gameObject.SetActive(false);
    }

    public void ProcessDeath() {
        // trigger death anim
        // play sound
        DropExp();
    }

    public void DropExp() {
        
    }
}