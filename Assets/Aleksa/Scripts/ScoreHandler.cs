using System;
using UnityEngine;

public class ScoreHandler : MonoBehaviour
{
    private int NumberOfPickedUp;
    private int TotalPartsDelivered;
    
    public int scoreForWin;

    public void PickUpPart()
    {
        NumberOfPickedUp++;
        print("Score increased : " + NumberOfPickedUp);
    }

    public void DeliverParts()
    {
        TotalPartsDelivered += NumberOfPickedUp;
        NumberOfPickedUp = 0;
        
        print("Delivered parts: " + TotalPartsDelivered);

        if (TotalPartsDelivered >= scoreForWin)
        {
            print("Won the game");
        }
    }
}