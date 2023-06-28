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
        if(inputKeyUI.FillSlider())
        {
            player.LoadScene(ELoadScene.UnderWater);
            CanPerform = !CanPerform;
        }
    }

    private void Update()
    {
        interactionUI.SetActive(on);
    }
}
