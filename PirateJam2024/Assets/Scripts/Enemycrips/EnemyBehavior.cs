using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehavior : MonoBehaviour
{
    NavMeshAgent navMeshAgent;
    Transform target;
    Animator animator;
    // Start is called before the first frame update
    void Awake()
    {
        navMeshAgent = transform.parent.GetComponentInChildren<NavMeshAgent>();
        target = GameObject.FindWithTag("Player").transform;
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        HuntPlayer();
        if (Vector3.Distance(transform.position, target.position) <= navMeshAgent.stoppingDistance) {
            animator.SetBool("Pursue", false);
        }
    }

    private void HuntPlayer()
    {
        animator.SetBool("Pursue", true);
        navMeshAgent.enabled = true;
        navMeshAgent.destination = target.position;
    }
}
