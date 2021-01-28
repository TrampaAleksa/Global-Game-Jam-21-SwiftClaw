using UnityEngine;

public class ScareField : MonoBehaviour
{
    public Transform[] runToPoints;

    private void ScarePlayer(PlayerScareController scareController)
    {
        scareController.RunToPoint(runToPoints[Random.Range(0, runToPoints.Length)]);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ScarePlayer(other.GetComponent<PlayerScareController>());
        }
    }
}