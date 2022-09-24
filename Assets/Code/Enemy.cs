using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{

    //Outlet
    NavMeshAgent navAgent;

    //Configuration
    public Transform target;

    //Methods
    void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();
    }
    void Update()
    {
        if (target)
        {
            navAgent.SetDestination(target.position);
        }
    }
}