﻿using System;
using UnityEngine;
using UnityEngine.AI;

public class PlayerAiController : MonoBehaviour
{
    private NavMeshAgent navmesh;
    [NonSerialized]public PlayerMovement _playerMovement;

    public Animator animator;

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
        // _playerMovement.enabled = false;
    }

    public void DisableAi()
    {
        navmesh.enabled = false;
        GameManager.Instance.playerAnimator.SetTrigger("FinishRunning");
        _playerMovement.enabled = true;
    }
}