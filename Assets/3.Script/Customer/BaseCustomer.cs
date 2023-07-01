using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCustomer : MonoBehaviour
{
    [SerializeField] protected GameObject interactionUI;
    [SerializeField] protected GameObject interactionUI2;

    private GameObject[] dd;
    private bool isOn { get; set; } = false;

    private void Start()
    {
        dd = new GameObject[] { interactionUI, interactionUI2 };
    }
    public virtual void Tea()
    {
        UIManager.Instance.SushiUI(!isOn, dd);
        isOn = !isOn;
    }
}
