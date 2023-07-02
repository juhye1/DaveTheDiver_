using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerInteraction : BaseInteraction
{
    private void Awake()
    {
        customer = GetComponent<BaseCustomer>();
    }

    private BaseCustomer customer;

    public override bool CanPerform()
    {
        return true;
    }

    public override void Perform()
    {
        customer.Interaction();
        switch(interactionType)
        {
            case EInteractionType.Enter:
                interactionType = EInteractionType.Tick;
                break;
            case EInteractionType.Tick:
                //customer.Interaction();
                break;
            case EInteractionType.End:
                //customer.Interaction();
                interactionType = EInteractionType.Enter;
                break;
        }
    }

    public override void ChangeType()
    {
        interactionType = EInteractionType.End;
    }


}
