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
        if(!isOn)
        {
            base.Interaction();
        }
        else
        {
            spawner.SpawnTea();
        }


    }
}
