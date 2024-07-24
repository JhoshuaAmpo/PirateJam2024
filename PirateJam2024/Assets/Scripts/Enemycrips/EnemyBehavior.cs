using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehavior : MonoBehaviour
{
    NavMeshAgent navMeshAgent;
    Transform target;
    // Start is called before the first frame update
    void Awake()
    {
        navMeshAgent = transform.parent.GetComponentInChildren<NavMeshAgent>();
        target = GameObject.FindWithTag("Player").transform;    
    }

    // Update is called once per frame
    void Update()
    {
        navMeshAgent.enabled = true;
        navMeshAgent.destination = target.position;
    }
}
