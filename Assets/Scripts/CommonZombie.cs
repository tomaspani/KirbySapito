using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class CommonZombie : Enemy
{
    public Transform player;
    private Rigidbody _myRB;
    private Animator _myAnim;

    [Header("Values")]
    [SerializeField] private float _chaseRadius;
    [SerializeField] private float _attackRadius;

    private void Awake()
    {
        _myAnim = GetComponentInChildren<Animator>();
        _myRB = GetComponent<Rigidbody>();
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void FixedUpdate()
    {
        float distance = Vector3.Distance(player.position, transform.position);
        
        if (distance <= _chaseRadius && distance > _attackRadius)
        {
            _navMeshAgent.SetDestination(player.position);
            transform.LookAt(player);
        }

    }

    public override void Attack()
    {

    }

    private void FollowPlayer()
    {
      
    }

}