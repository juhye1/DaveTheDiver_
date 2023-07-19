using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
public abstract class UIBase : MonoBehaviour
{
    protected UIInput inputUI;
    protected InputKeyUI inputKeyUI;
    public abstract void OFFUI();

    private void Awake()
    {
        inputKeyUI = FindObjectOfType<InputKeyUI>();
    }
}
