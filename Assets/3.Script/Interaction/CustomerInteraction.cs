using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerInteraction : BaseInteraction
{
    private void Awake()
    {
        customer = GetComponent<BaseCustomer>();
        interactionType = EInteractionType.Tick;
    }

    private BaseCustomer customer;

    public override bool CanPerform()
    {
        return true;
    }

    public override void Instantaneous()
    {
        customer.Interaction();
    }

    public override void OverTime()
    {
        throw new System.NotImplementedException();
    }
}
