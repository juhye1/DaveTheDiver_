using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BaseObject : MonoBehaviour
{
    public bool CanPerform { get; protected set; } = true;
    [SerializeField] protected GameObject interactionUI;

    protected MovePointUI movePointUI;
    protected InputKeyUI inputKeyUI;
    protected PlayerInteraction player;
    protected BaseInteraction interaction;
    protected bool on => player.MovePoint(interaction);

    private void Awake()
    {
        movePointUI = FindObjectOfType<MovePointUI>();
        interaction = GetComponent<BaseInteraction>();
        player = FindObjectOfType<PlayerInteraction>();
    }
    protected bool isOn { get; set; } = false;

    public virtual void Interaction()
    {
        UIManager.Instance.InteractionUI(!isOn, interactionUI);
        isOn = !isOn;
    }

}
