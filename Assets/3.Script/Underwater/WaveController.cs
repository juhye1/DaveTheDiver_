using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class WaveController : MonoBehaviour
{
    private void Start()
    {
        transform.DOLocalMoveX(50, 60);
    }
}
