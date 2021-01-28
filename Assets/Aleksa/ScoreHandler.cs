using UnityEngine;

public class ScoreHandler : MonoBehaviour
{
    private static int NumberOfPickedUp;

    public void IncreaseScore()
    {
        NumberOfPickedUp++;
        print("Score increased : " + NumberOfPickedUp);
    }
}