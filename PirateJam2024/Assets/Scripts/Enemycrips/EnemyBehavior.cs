using System;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehavior : MonoBehaviour
{
    [SerializeField]
    [Range(0,180)]
    [Tooltip("Half field of view in degrees")]
    int HalfFOV;

    NavMeshAgent navMeshAgent;
    Transform target;
    Animator animator;

    bool isPursuing = false;
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
        if (isPursuing) {
            HuntPlayer();
        }
        // if (Vector3.Distance(transform.position, target.position) <= navMeshAgent.stoppingDistance) {
        //     animator.SetBool("Pursue", false);
        // }
    }

    private void OnTriggerStay(Collider other) {
        if (!other.CompareTag("Player") || isPursuing) {return;}
        if (PlayerInFOV()) {
            isPursuing = true;
        }
    }

    void Idle() {

    }

    // Only call in on trigger
    private bool PlayerInFOV() {
        Vector3 dirToPlayer = target.transform.position - transform.position;
        dirToPlayer.y = 0;
        float angle = Vector3.Angle(dirToPlayer, transform.forward);
        Debug.Log("Angle diff between player and " + gameObject.name + ": " + angle);
        return angle < HalfFOV;
    }

    private void HuntPlayer()
    {
        animator.SetBool("Pursue", true);
        navMeshAgent.enabled = true;
        navMeshAgent.destination = target.position;
    }
}
