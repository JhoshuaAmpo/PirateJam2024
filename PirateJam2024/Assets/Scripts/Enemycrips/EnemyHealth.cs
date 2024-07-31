
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Unity.VisualScripting;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    private float maxHealth = 100;

    EnemySoundMaker enemySoundMaker;

    private float currentHealth;
    private ExpDrop expDrop;

    // Start is called before the first frame update
    void Awake()
    {
        currentHealth = maxHealth;
        enemySoundMaker = GetComponent<EnemySoundMaker>();
        // expDrop = transform.parent.GetComponentInChildren<ExpDrop>();
        // if (expDrop == null) { 
        //     Debug.LogError("Enemy has not exp item");
        // }
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
        enemySoundMaker.PlayAttack();
        currentHealth -= damage;
        if (currentHealth <= 0) {
            ProcessDeath();
        }
    }

    public void ProcessDeath() {
        // trigger death anim
        // play sound
        // Debug.Log(gameObject.name + " died");
        // DropExp();
        gameObject.SetActive(false);
    }

    public void DropExp() {
        expDrop.gameObject.SetActive(true);
    }
}