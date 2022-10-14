using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class CommonZombie : Enemy
{
    public Transform player;
    private Rigidbody _myRB;
    private Animator _myAnim;

    private void Awake()
    {
        _myAnim = GetComponentInChildren<Animator>();
        _myRB = GetComponent<Rigidbody>();
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void FixedUpdate()
    {
        _navMeshAgent.SetDestination(player.position);
        transform.LookAt(player);
    }

    public override void Attack()
    {

    }

}