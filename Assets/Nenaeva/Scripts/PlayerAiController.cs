using System;
using UnityEngine;
using UnityEngine.AI;

public class PlayerAiController : MonoBehaviour
{
    private NavMeshAgent navmesh;
    private PlayerMovement _playerMovement;

    private void Awake()
    {
        navmesh = GetComponent<NavMeshAgent>();
        navmesh.isStopped = true;
        _playerMovement = GetComponent<PlayerMovement>();
    }

    public void SetTarget(Transform target)
    {
        navmesh.isStopped = false;
        navmesh.SetDestination(target.position);
        _playerMovement.enabled = false;
    }

    public void DisableAi()
    {
        navmesh.isStopped = true;
        _playerMovement.enabled = true;
    }
}