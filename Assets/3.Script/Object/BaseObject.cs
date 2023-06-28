using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseObject : MonoBehaviour
{
    [SerializeField] protected GameObject interactionUI;
    private bool isOn { get; set; } = false;

    public virtual void Interaction()
    {
        UIManager.Instance.InteractionUI(!isOn, interactionUI);
        isOn = !isOn;
    }

}
