public class GetTreated : GoapAction
{
    public override bool PrePerform()
    {
        target = inventory.FindItemWithTag("Cubicle");
        return target != null;
    }

    public override bool PostPerform()
    {
        GoapWorld.Instance.GetWorld().UpdateState("TesterTreated", 1);
        agentStates.UpdateState("TesterTested", 1);
        if (target != null)
            inventory.RemoveItem(target);
        return true;
    }
}
