using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerInteraction : BaseInteraction
{
    private BaseCustomer customer;

    public override bool CanPerform()
    {
        return true;
    }

    public override void Perform()
    {
        customer.Tea();
    }

    private void Awake()
    {
        customer = GetComponent<BaseCustomer>();
    }
}
