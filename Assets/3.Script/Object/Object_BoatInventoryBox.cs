using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_BoatInventoryBox : BaseObject
{
    private DiverBox_Inventory dd;
    private bool On => player.InteractionCheck(interaction);

    private void Start()
    {
        dd = FindObjectOfType<DiverBox_Inventory>();
    }
    private void Update()
    {
        if(On)
        {
            UIInputManager.Instance.SetInputUI(dd);
        }
    }

}
