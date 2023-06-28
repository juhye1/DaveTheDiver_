using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class LoadingUI : MonoBehaviour
{
    private CanvasGroup group;
    private void Awake()
    {
        group = GetComponentInChildren<CanvasGroup>();
        group.alpha = 0;
    }
    private void Start()
    {
        group.DOFade(1, 0.5f);
    }
}
