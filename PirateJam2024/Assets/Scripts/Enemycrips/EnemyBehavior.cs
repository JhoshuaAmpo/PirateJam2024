using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehavior : MonoBehaviour
{
    [SerializeField]
    [Range(0,180)]
    [Tooltip("Half field of view in degrees")]
    int HalfFOV;
    [SerializeField]
    List<Vector3> pathing;
    [SerializeField]
    float maxHP;
    [Header("Attack Settings")]
    [SerializeField]
    float attackDamage;
    [SerializeField]
    float attackCooldown;

    NavMeshAgent navMeshAgent;
    Transform target;
    Animator animator;
    EnemySoundMaker enemySoundMaker;
    EnemyStrikeZone enemyStrikeZone;
    bool isPursuing = false;
    float currentHP;
    float timer;

    // Start is called before the first frame update
    void Awake()
    {
        navMeshAgent = transform.parent.GetComponentInChildren<NavMeshAgent>();
        target = GameObject.FindWithTag("Player").transform;
        animator = GetComponentInChildren<Animator>();
        enemySoundMaker = GetComponent<EnemySoundMaker>();
        enemyStrikeZone = GetComponentInChildren<EnemyStrikeZone>();
        currentHP = maxHP;
    }

    // Update is called once per frame
    void Update()
    {
        // HuntPlayer();
        if (Vector3.Distance(target.position, transform.position) <= navMeshAgent.stoppingDistance)
        {
            animator.SetBool("Pursue", false);
            animator.applyRootMotion = true;
            if (timer <= 0) {
                Attack();
            }
        }
        else if (isPursuing) {
            HuntPlayer();
        }
        else {
            Idle();
        }

        if (timer > 0) {
            timer -= Time.deltaTime;
            timer = MathF.Max(0, timer);
        }
    }

    private void Idle() {
        animator.applyRootMotion = true;
    }

    private void Attack()
    {
        // Play attack sfx
        enemySoundMaker.PlayAttack();
        animator.SetTrigger("Attack");
        timer = attackCooldown;
        if (enemyStrikeZone.IsPlayerInStrikeZone) {
            target.GetComponent<PlayerHealth>().TakeDamage(attackDamage);
        }
    }

    private void OnTriggerStay(Collider other) {
        if (!other.CompareTag("Player") || isPursuing) {return;}
        if (PlayerInFOV()) {
            isPursuing = true;
        }
    }


    // Only call in on trigger
    private bool PlayerInFOV() {
        Vector3 dirToPlayer = target.transform.position - transform.position;
        dirToPlayer.y = 0;
        float angle = Vector3.Angle(dirToPlayer, transform.forward);
        // Debug.Log("Angle diff between player and " + gameObject.name + ": " + angle);
        return angle < HalfFOV;
    }

    private void HuntPlayer()
    {
        animator.SetBool("Pursue", true);
        enemySoundMaker.PlayMove();
        animator.applyRootMotion = false;
        navMeshAgent.enabled = true;
        navMeshAgent.destination = target.position;
    }
}
