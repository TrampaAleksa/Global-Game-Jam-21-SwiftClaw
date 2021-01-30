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
        _playerMovement = GetComponent<PlayerMovement>();
    }

    private void Start()
    {
        navmesh.enabled = false;
    }

    public void SetTarget(Transform target)
    {
        navmesh.enabled = true;
        navmesh.SetDestination(target.position);
        _playerMovement.enabled = false;
    }

    public void DisableAi()
    {
        navmesh.enabled = false;
        _playerMovement.enabled = true;
    }
}