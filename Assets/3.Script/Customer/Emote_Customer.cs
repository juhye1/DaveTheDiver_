using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Emote_Customer : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite[] sprites;
    private Sequence sequence;
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        sequence = DOTween.Sequence().Pause();
        sequence.Append(spriteRenderer.DOFade(1, 0.01f))
                .Append(transform.DOScale(Vector3.one * 0.7f, 1f).SetEase(Ease.InBounce))
                .Append(spriteRenderer.DOFade(0, 0.5f)).OnComplete(() => spriteRenderer.enabled = false);

        spriteRenderer.enabled = false;

    }


    public void PlayEmote(Customer.EState eState)
    {

        spriteRenderer.enabled = true;
        switch (eState)
        {
            case Customer.EState.Eat:
                spriteRenderer.sprite = sprites[0];break;
            case Customer.EState.Angry:
                spriteRenderer.sprite = sprites[1]; break;
        }
        sequence.Play();
    }

}
