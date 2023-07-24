using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class ChapterUI : MonoBehaviour
{
    private InputKeyUI inputKeyUI;
    private Sequence sequence;
    private TextMeshProUGUI tmp;
    private CanvasGroup canvasGroup;
    [SerializeField] private GameObject mainUI;
    Player player;


    [SerializeField] private Transform line;

    private void Awake()
    {
        inputKeyUI = FindObjectOfType<InputKeyUI>();
        player = FindObjectOfType<Player>();
        tmp = GetComponentInChildren<TextMeshProUGUI>();
        canvasGroup = GetComponent<CanvasGroup>();
        canvasGroup.alpha = 0;
        inputKeyUI.UIOn(false);
        Init();
    }

    private void Start()
    {
        //DOTween.Play(sequence);
    }

    private void OnEnable()
    {
        Invoke("PlaySound", 1);

        player.SwitchActionMapUI(true, Player.EState.Lobby);
        sequence.Play();
    }

    private void PlaySound()
    {
        SoundManager.Instance.PlaySE(ESE.UI_Mission);
    }

    private void Init()
    {
        sequence = DOTween.Sequence().Pause();
        sequence.Append(canvasGroup.DOFade(1, 1))
                .Append(line.DOScaleX(1, 0.5f))
                .Join(tmp.rectTransform.DOLocalMoveY(0, 1).SetEase(Ease.OutBack))
                .AppendInterval(1)
                .Append(canvasGroup.DOFade(0, 1))
                .OnComplete(() => CompleteSet());
    }

    private void CompleteSet()
    {
        player.SwitchActionMapUI(false, Player.EState.Lobby);
        mainUI.SetActive(true);
        inputKeyUI.UIOn(true);

    }
}
