using UnityEngine;

public class ScoreHandler : MonoBehaviour
{
    private static int NumberOfPickedUp;
    public int scoreForWin;

    public void IncreaseScore()
    {
        NumberOfPickedUp++;
        print("Score increased : " + NumberOfPickedUp);

        if (NumberOfPickedUp >= scoreForWin)
        {
            print("Won the game!");
        }
    }
}