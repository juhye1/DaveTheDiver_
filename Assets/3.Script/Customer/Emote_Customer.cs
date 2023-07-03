using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Emote_Customer : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Sequence sequence;
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        sequence = DOTween.Sequence().Pause();
        sequence.Append(transform.DOScale(Vector3.one * 0.7f, 0.5f).SetEase(Ease.InBounce))
                .Append(spriteRenderer.DOFade(0, 0.5f));

    }

    private void OnEnable()
    {
        sequence.Play();
    }
}
