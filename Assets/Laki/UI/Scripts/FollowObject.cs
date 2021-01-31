using UnityEngine;

public class FollowObject : MonoBehaviour
{
    public Transform toFollow;

    public void Update()
    {
        var transformOfObject = transform;
        transformOfObject.position = new Vector3(toFollow.position.x, transformOfObject.position.y, toFollow.position.z);
    }
}