using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer_Tea : BaseCustomer
{
    private Spawner spawner;

    private void Start()
    {
        spawner = FindObjectOfType<Spawner>();
    }
    public override void Interaction()
    {
        switch(baseInteraction.InteractionType)
        {
            case BaseInteraction.EInteractionType.Enter:
                spawner.ResetTea();
                base.Interaction(); 

                break;
            case BaseInteraction.EInteractionType.Tick:
                spawner.SpawnTea();
                break;
            case BaseInteraction.EInteractionType.End:
                spawner.ResetTea();
                base.Interaction();
                break;

        }
    }
}
