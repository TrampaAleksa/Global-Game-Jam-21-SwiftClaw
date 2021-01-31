using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateLight : MonoBehaviour
{
    public Vector3 axis;
    public float add;
    public float time;
    private void Update()
    {
        gameObject.LeanRotateAroundLocal(axis, add, time);
    }
}
