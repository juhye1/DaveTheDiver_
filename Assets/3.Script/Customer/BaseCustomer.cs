using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCustomer : MonoBehaviour
{
    [SerializeField] protected GameObject interactionUI;
    [SerializeField] protected GameObject interactionUI2;
    [SerializeField] protected GameObject ScoreUI;

    protected BaseInteraction baseInteraction;
    public bool CanPerform { get; protected set; } = true;

    private GameObject[] dd;
    protected bool isOn { get; set; } = false;

    private void Awake()
    {
        baseInteraction = GetComponent<BaseInteraction>();
        dd = new GameObject[] { interactionUI, interactionUI2, ScoreUI };
    }
    public virtual void Interaction()
    {
        UIManager.Instance.SushiUI(!isOn, dd);
        isOn = !isOn;
    }
}
