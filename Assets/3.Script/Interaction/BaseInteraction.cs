using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseInteraction : MonoBehaviour
{
    public enum EInteractionType
    {
        Enter,
        Tick
    }
    [SerializeField] protected Transform interactionMarker;
    public Vector3 Point => interactionMarker != null ? interactionMarker.position : transform.position;
    protected List<BaseInteraction> interactions;
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

    public abstract void Instantaneous();
    public abstract void OverTime();
    public abstract bool CanPerform();

}
