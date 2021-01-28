using System;
using UnityEngine;
using UnityEngine.AI;

public class PlayerAiController : MonoBehaviour
{
    private NavMeshAgent navmesh;
    public Transform target;

    private PlayerMovement _playerMovement;

    private void Awake()
    {
        navmesh = GetComponent<NavMeshAgent>();
        navmesh.enabled = false;
        _playerMovement = GetComponent<PlayerMovement>();
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

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            SetTarget(target);
        }
    }
}