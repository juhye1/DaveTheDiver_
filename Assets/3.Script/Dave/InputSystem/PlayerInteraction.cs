using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : Player
{
    private BaseInteraction movePointinteraction;
    public bool Interaction()
    {
        if (state.Equals(EState.UI))
            return false;

        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.forward, settings.DetectRange, settings.InteractableMask);
        if (hit.collider != null)
        {
            interaction = hit.transform.GetComponent<BaseInteraction>();
            Point = interaction.Point;
            return true;
        }
        else
        {
            interaction = null;
        }
        return false;

    }



    public bool MovePoint(BaseInteraction baseInteraction)
    {
        if (!state.Equals(EState.Lobby))
            return false;

        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.forward, settings.DetectRange, settings.MovePointMask);
        if (hit.collider != null)
        {
            movePointinteraction = hit.transform.GetComponent<BaseInteraction>();
            Point = movePointinteraction.Point;
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
