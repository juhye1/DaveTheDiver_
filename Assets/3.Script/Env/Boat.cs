using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Boat : MonoBehaviour
{
    private void Start()
    {
        transform.DOMoveY(0, 5).SetEase(Ease.InOutBounce);
    }
}
