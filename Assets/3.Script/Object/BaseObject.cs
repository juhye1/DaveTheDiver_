using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseObject : MonoBehaviour
{
    public bool CanPerform { get; protected set; } = true;
    [SerializeField] protected GameObject interactionUI;
    protected InputKeyUI inputKeyUI;
    protected Player player;
    protected BaseInteraction interaction;
    protected bool on => player.MovePoint(interaction);

    private void Awake()
    {
        interaction = GetComponent<BaseInteraction>();
        player = FindObjectOfType<Player>();
    }
    private bool isOn { get; set; } = false;

    public virtual void Interaction()
    {
        UIManager.Instance.InteractionUI(!isOn, interactionUI);
        isOn = !isOn;
    }

}
