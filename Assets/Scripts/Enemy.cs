using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public abstract class Enemy : MonoBehaviour
{
    [Header("Values")]
    [SerializeField] private float _life;
    [SerializeField] private float _maxLife;
    [SerializeField] private float _damage;
    [SerializeField] private float _speed;
    protected NavMeshAgent _navMeshAgent; //esta bien asi???????


    public abstract void Attack();

    public void TakeDamage()
    {

    }

}
