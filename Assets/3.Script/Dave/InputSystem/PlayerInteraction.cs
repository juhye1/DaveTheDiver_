using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : Player
{
    private BaseInteraction movePointinteraction;
    public bool Interaction()
    {
        //UI일때도 이거해야해~~~~~~~~~~~

        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.forward, settings.DetectRange, settings.InteractableMask);
        if (hit.collider != null)
        {
            interaction = hit.transform.GetComponent<BaseInteraction>();
            Point = interaction.Point;
            if (hit.transform.TryGetComponent<UIInput>(out var dd))
            {
                UIInputManager.Instance.SetInputUI(dd);
            }

            if (!state.Equals(EState.UI)||!state.Equals(EState.Load))
                return true;
        }
        else
        {
            interaction = null;
        }
            return false;

    }

    public bool InteractionCheck(BaseInteraction baseInteraction)
    {
        //UI일때도 이거해야해~~~~~~~~~~~

        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.forward, settings.DetectRange, settings.InteractableMask);
        if (hit.collider != null)
        {
            interaction = hit.transform.GetComponent<BaseInteraction>();
            Point = interaction.Point;

            if (!state.Equals(EState.UI) || !state.Equals(EState.Load))
            {
                if (baseInteraction == interaction)
                {
                    return true;
                }
            }
 
        }
        else
        {
            interaction = null;
        }
        return false;

    }



    public bool MovePoint(BaseInteraction baseInteraction)
    {


        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.forward, settings.DetectRange, settings.MovePointMask);
        if (hit.collider != null)
        {
            movePointinteraction = hit.transform.GetComponent<BaseInteraction>();
            Point = movePointinteraction.Point;

            if (state.Equals(EState.Load) || state.Equals(EState.UI))
                return false;

            if (baseInteraction == movePointinteraction)
            {
                return true;
            }
        }
        else
        {
            movePointinteraction = null;
        }
        return false;
    }
}
