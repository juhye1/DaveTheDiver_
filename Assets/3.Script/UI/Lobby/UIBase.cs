using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public abstract class UIBase : MonoBehaviour
{
    [SerializeField] protected Image background;
    protected UIInput inputUI;
    protected InputKeyUI inputKeyUI;

    public abstract void OFFUI();

    private void Awake()
    {
        inputKeyUI = FindObjectOfType<InputKeyUI>();
        inputUI = GetComponent<UIInput>();
    }
}
