using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerInteraction : BaseInteraction
{
    private BaseCustomer baseCustomer;
    private Customer customer;
    private void Awake()
    {
        baseCustomer = GetComponent<BaseCustomer>();
        customer = GetComponent<Customer>();
    }


    public override bool CanPerform()
    {
        return true;
    }

    public override void Perform()
    {
        switch(customer.OrderType)
        {
            case Customer.EOrderType.Tea:
                Tea();
                break;
            case Customer.EOrderType.Sushi:
                baseCustomer.Sushi();
                break;


        }


    }

    public override void ChangeType()
    {
        interactionType = EInteractionType.End;
    }

    public void Tea()
    {
        baseCustomer.Tea();
        switch (interactionType)
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

}
