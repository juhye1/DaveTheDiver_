using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_DiveTrigger : BaseObject
{
    public bool isDiveTrigger => movePoint;


    public override void Interaction()
    {
        if(inputKeyUI==null)
        {
            inputKeyUI = FindObjectOfType<InputKeyUI>();
        }
    }

    private void Update()
    {
        movePointUI.OnDiveUI(movePoint);
    }
}
