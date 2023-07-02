using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCustomer : MonoBehaviour
{
    protected BaseInteraction baseInteraction;
    public bool CanPerform { get; protected set; } = true;

    private GameObject[] TeaUI;
    protected bool isOn { get; set; } = false;

    private void Awake()
    {
        baseInteraction = GetComponent<BaseInteraction>();
    }
    public virtual void Interaction()
    {
        UIManager.Instance.SushiUI(!isOn, TeaUI);
        isOn = !isOn;
    }

    public void Init(GameObject[] gameObjects)
    {
        TeaUI = gameObjects;
    }
}
