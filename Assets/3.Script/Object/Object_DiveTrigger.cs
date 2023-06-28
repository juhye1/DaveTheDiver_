using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_DiveTrigger : BaseObject
{

    public override void Interaction()
    {
        if(inputKeyUI==null)
        {
            inputKeyUI = FindObjectOfType<InputKeyUI>();
        }
        if(inputKeyUI.dd())
        {
            CanPerform = !CanPerform;
        }
    }

    private void Update()
    {
        interactionUI.SetActive(on);
    }
}
