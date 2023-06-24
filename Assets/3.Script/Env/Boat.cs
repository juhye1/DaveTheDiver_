using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Boat : MonoBehaviour
{
    private void Start()
    {
        //transform.DOMoveY(0, 1).SetEase(Ease.InOutQuint);
        transform.DOPunchPosition(Vector3.up, 1,1);
    }
}
