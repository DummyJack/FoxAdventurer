using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum EnemyState {
    IDLE,
    WALK,
    ATTACK
}

public class EnemyController : MonoBehaviour
{
    private EnemyState currentState = EnemyState.IDLE;
    private Animator animator;
    private NavMeshAgent agent;

    public Transform player;
    void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
