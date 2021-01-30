using System;
using UnityEngine;

public class ScoreHandler : MonoBehaviour
{
    [NonSerialized]public int NumberOfPickedUp;
    [NonSerialized]public int TotalPartsDelivered;
    
    public AudioSource shipRepairSound;
    
    public int scoreForWin;

    public void PickUpPart()
    {
        NumberOfPickedUp++;
        print("Score increased : " + NumberOfPickedUp);
    }

    public void DeliverParts()
    {
        if (NumberOfPickedUp == 0) return;
        
        TotalPartsDelivered += NumberOfPickedUp;
        NumberOfPickedUp = 0;
        
        print("Delivered parts: " + TotalPartsDelivered);

        if (TotalPartsDelivered >= scoreForWin)
        {
            print("Won the game");
            return;
        }

        shipRepairSound.Play();
    }
}