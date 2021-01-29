using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class ScareField : MonoBehaviour
{
    public Transform[] runToPoints;
    public ScareFieldSource fieldSource;

    private BoxCollider collider;

    private void Awake()
    {
        fieldSource = transform.parent.GetComponent<ScareFieldSource>();
        collider = GetComponent<BoxCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ScarePlayer();
        }
    }

    private void ScarePlayer()
    {
        fieldSource.SetFieldState(ScareFieldState.Inactive);
        GameManager.Instance.scareHandler.RunToPoint(runToPoints[Random.Range(0, runToPoints.Length)], this);
    }

    public void SetFieldState(ScareFieldState state)
    {
        if (state == ScareFieldState.Active)
        {
            collider.enabled = true;
            return;
        }
        
        if (state == ScareFieldState.Inactive)
        {
            collider.enabled = false;
        }
    }
}

public enum ScareFieldState
{
    Active, 
    Inactive,
}