using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class CommonZombie : Enemy
{
    private Rigidbody _myRB;
    private Animator _myAnim;

    private void Awake()
    {
        _myAnim = GetComponentInChildren<Animator>();
        _myRB = GetComponent<Rigidbody>();
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    public override void Attack()
    {

    }

}