using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseInteraction : MonoBehaviour
{
    [SerializeField] protected Transform interactionMarker;
    public Vector3 Point => interactionMarker != null ? interactionMarker.position : transform.position;
    protected List<BaseInteraction> interactions;
    protected bool IsStart;

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

}
