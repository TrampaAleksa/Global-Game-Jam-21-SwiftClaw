public class LightPickup : PickupItem
{
    public int value;
    protected override void TriggeredPickup()
    {
        base.TriggeredPickup();
        GameManager.Instance.lightHandler.AddLight(15);
        print("picked up light ");
    }
}