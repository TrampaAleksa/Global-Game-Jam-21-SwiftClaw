public class ScorePickup : PickupItem
{
    protected override void TriggeredPickup()
    {
        base.TriggeredPickup();
        GameManager.Instance.scoreHandler.PickUpPart();
        GameManager.Instance.soundHandler.pickupPart.Play();
        print("picked up score: ");
        GameManager.Instance.lightHandler.lamp.gradient.LampIsFar();
        Destroy(gameObject);
    }
}