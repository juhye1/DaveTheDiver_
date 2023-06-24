using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class DialogueUI : UIBase
{
    [SerializeField] private Transform LeftPanel;
    [SerializeField] private Transform RightPanel;
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
                .Append(LeftPanel.DOLocalMoveY(54, 1).SetEase(Ease.OutBack))
                .Append(tmp.DOText("그러고 보니 데이브,\n<color=#F1DC2B>총</color>은 잘 사용하고 있나?", 1).SetEase(Ease.Linear));
    }

}
