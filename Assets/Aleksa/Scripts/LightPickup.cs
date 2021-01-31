public class LightPickup : PickupItem
{
    public int value;
    protected override void TriggeredPickup()
    {
        base.TriggeredPickup();
        GameManager.Instance.lightHandler.AddLight(15);
        print("picked up light ");
        GameManager.Instance.soundHandler.lightPickup.Play();
        GameManager.Instance.gameObject.AddComponent<TimedAction>().StartTimedAction(() => gameObject.SetActive(true), GameManager.Instance.lightHandler.fireflyCooldown);
        // Destroy(gameObject);
        gameObject.SetActive(false);
    }
}