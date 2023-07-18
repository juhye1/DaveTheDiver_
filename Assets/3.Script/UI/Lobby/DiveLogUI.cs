using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class DiveLogUI : MonoBehaviour
{
    private Sequence sequence;
    private Vector2 home;

    [Header("Dive Log")]
    [SerializeField] private TextMeshProUGUI DiveNo;
    [SerializeField] private Image BiggestFish;
    [SerializeField] private RectTransform DiveLogTransform;

    [Header("Fish Log")]
    [SerializeField] private RectTransform FishLogTransform;

    [SerializeField] private RectTransform BanchoImage;
    private InputKeyUI inputKeyUI;
    private Player player;
    //바다에 있다가 로비로 왔을때만 떠야되고
    //머 잡아왔는지 떠야함
    //뒤에 블러 켜야하고
    //

    private void Awake()
    {
        inputKeyUI = FindObjectOfType<InputKeyUI>();
        player = FindObjectOfType<Player>();
        sequence = DOTween.Sequence().Pause();
        sequence.Append(BanchoImage.DOScale(1, 1).SetEase(Ease.InCirc))
                .AppendInterval(1)
                .Append(BanchoImage.DOScale(0.1f, 1).SetEase(Ease.InCirc));

        BanchoImage.gameObject.SetActive(false);
        home = new Vector2(0, -1000);

        DiveLogTransform.localPosition = home;
        FishLogTransform.localPosition = home;
    }

    public void DiveLogUIOn()
    {
        DiveLogTransform.DOLocalMoveY(0, 1).SetEase(Ease.OutBounce);
    }

    public void FishLogUIOn()
    {
        DiveLogTransform.localPosition = home;
        DiveLogTransform.gameObject.SetActive(false);
        FishLogTransform.DOLocalMoveY(0, 1).SetEase(Ease.OutBounce).OnComplete(() => inputKeyUI.UIOn(true));
        
    }

    public void OFFUI()
    {
        inputKeyUI.UIOn(false);
        FishLogTransform.localPosition = home;
        FishLogTransform.gameObject.SetActive(false);
        BanchoImage.gameObject.SetActive(true);
        UIManager.Instance.SetBlur(false);
        sequence.Play().OnComplete(() => CompleteSet());
    }

    private void CompleteSet()
    {
        inputKeyUI.UIOn(true);
        BanchoImage.gameObject.SetActive(false);
        player.SwitchActionMapUI(false , Player.EState.Lobby);
    }

}
