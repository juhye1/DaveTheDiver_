using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseInteraction : MonoBehaviour
{
    public enum EInteractionType
    {
        Enter,
        Tick,
        End
    }
    [SerializeField] protected Transform interactionMarker;
    public Vector3 Point => interactionMarker != null ? interactionMarker.position : transform.position;
    protected bool IsStart;
    public EInteractionType InteractionType => interactionType;
    protected EInteractionType interactionType = EInteractionType.Enter;

/*    public List<BaseInteraction> Interactions
    {
        get
        {
            if (interactions == null)
                interactions = new List<BaseInteraction>(GetComponents<BaseInteraction>());

            return interactions;
        }
    }*/

    public abstract void Perform();
    public abstract bool CanPerform();

    public virtual void ChangeType()
    {
        
    }

}
