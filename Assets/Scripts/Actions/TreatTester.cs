public class TreatTester : GoapAction
{
    public override bool PrePerform()
    {
        target = inventory.FindItemWithTag("Cubicle");
        GoapWorld.Instance.GetWorld().UpdateState("TreatingTester", 1);
        return target == null ? false : true;
    }

    public override bool PostPerform()
    {
        GoapWorld.Instance.GetWorld().UpdateState("TreatingTester", -1);
        GoapWorld.Instance.AddCubicle(target);
        inventory.RemoveItem(target);
        GoapWorld.Instance.GetWorld().UpdateState("FreeCubicle", 1);
        return true;
    }
}
