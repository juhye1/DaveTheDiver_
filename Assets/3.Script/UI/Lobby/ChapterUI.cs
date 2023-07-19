using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class ChapterUI : MonoBehaviour
{
    protected Sequence sequence;
    protected TextMeshProUGUI tmp;
    protected CanvasGroup canvasGroup;


    [SerializeField] private Transform line;

    private void Awake()
    {
        tmp = GetComponentInChildren<TextMeshProUGUI>();
        canvasGroup = GetComponent<CanvasGroup>();
        canvasGroup.alpha = 0;
        Init();
    }

    private void Start()
    {
        DOTween.Play(sequence);
    }


    private void Init()
    {
        sequence = DOTween.Sequence();
        sequence.Append(canvasGroup.DOFade(1, 1))
                .Append(line.DOScaleX(1,0.5f))
                .Join(tmp.rectTransform.DOLocalMoveY(0, 1).SetEase(Ease.OutBack))
                .AppendInterval(1)
                .Append(canvasGroup.DOFade(0, 1));
    }
}
