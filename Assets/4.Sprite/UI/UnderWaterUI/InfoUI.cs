using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class InfoUI : MonoBehaviour
{
    private Vector2 home;
    private float homeX = -180;
    private Sequence sequence;
    //물고기 잡으면 나오게

    private void Awake()
    {
        home = new Vector2(-600, -104);
        transform.localPosition = home;
        sequence = DOTween.Sequence().Pause();
        sequence.Append(transform.DOLocalMoveX(-180, 1).SetEase(Ease.InQuart))
                .AppendInterval(1)
                .Append(transform.DOLocalMoveX(homeX, 1).SetEase(Ease.InQuart));
    }

    public void InfoOn()
    {
        sequence.Play();
    }


    private void OnDisable()
    {
        transform.localPosition = home;
    }
}
