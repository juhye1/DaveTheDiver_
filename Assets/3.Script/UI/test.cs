using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class test : MonoBehaviour
{
    private void Start()
    {
        RectTransform rect = GetComponent<RectTransform>();
        rect.DOAnchorPosY(50,1).SetEase(Ease.OutFlash);
    }


}
