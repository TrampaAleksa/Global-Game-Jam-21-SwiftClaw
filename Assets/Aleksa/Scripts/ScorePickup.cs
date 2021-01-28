public class ScorePickup : PickupItem
{
    protected override void TriggeredPickup()
    {
        base.TriggeredPickup();
        GameManager.Instance.scoreHandler.PickUpPart();
        print("picked up score: ");
    }
}