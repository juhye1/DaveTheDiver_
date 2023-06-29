using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCustomer : MonoBehaviour
{
    [SerializeField] protected GameObject interactionUI;
    private bool isOn { get; set; } = false;
    public virtual void Tea()
    {
        Debug.Log("D");
        UIManager.Instance.SushiUI(!isOn, interactionUI);
        isOn = !isOn;
    }
}
