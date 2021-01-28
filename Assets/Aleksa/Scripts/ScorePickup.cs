public class ScorePickup : PickupItem
{
    protected override void TriggeredPickup()
    {
        base.TriggeredPickup();
        GameManager.Instance.scoreHandler.IncreaseScore();
        print("picked up score: ");
    }
}