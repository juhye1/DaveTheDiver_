using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum EInteractionType
{
    NPC,
    Object
}

public abstract class BaseInteraction : MonoBehaviour
{
    [SerializeField] protected Transform interactionMarker;
    public Vector3 Point => interactionMarker != null ? interactionMarker.position : transform.position;
    protected EInteractionType type = EInteractionType.NPC;
    protected UIManager uiManager;
    protected List<BaseInteraction> interactions;
    protected bool IsStart;
    private void Awake()
    {
        uiManager = FindObjectOfType<UIManager>();
    }

    public List<BaseInteraction> Interactions
    {
        get
        {
            if (interactions == null)
                interactions = new List<BaseInteraction>(GetComponents<BaseInteraction>());

            return interactions;
        }
    }

    public abstract void Perform();

}
