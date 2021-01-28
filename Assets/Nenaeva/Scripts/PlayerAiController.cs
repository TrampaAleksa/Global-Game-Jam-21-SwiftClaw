using System;
using UnityEngine;
using UnityEngine.AI;

public class PlayerAiController : MonoBehaviour
{
    private NavMeshAgent navmesh;

    public Transform target;

    private void Awake()
    {
        navmesh = GetComponent<NavMeshAgent>();
    }

    public void SetTarget(Transform target)
    {
        navmesh.SetDestination(target.position);
        navmesh.enabled = true;
    }

    public void DisableAi()
    {
        navmesh.enabled = false;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            SetTarget(target);
        }
    }
}