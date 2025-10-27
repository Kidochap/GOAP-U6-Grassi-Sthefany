using UnityEngine;

public class GetTester : GoapAction
{
    GameObject resource;
    public override bool PrePerform()
    {
        target = GoapWorld.Instance.RemoveTester();
        // Se n�o houver tester, falha
        if (target == null) { return false; }
        // Captura o cub�culo livre
        resource = GoapWorld.Instance.RemoveCubicle();
        // Se existir um cub�culo livre, reserva-o
        if (resource != null) { inventory.AddItem(resource); }
        else
        {
            GoapWorld.Instance.AddTester(target);
            target = null;
            return false;
        }
        GoapWorld.Instance.GetWorld().UpdateState("FreeCubicle", -1);
        return true;
    }

    public override bool PostPerform()
    {
        GoapWorld.Instance.GetWorld().UpdateState("atWaitingRoom", -1);
        if (target) target.GetComponent<GoapAgent>().inventory.AddItem(resource);
        return true;
    }
}
