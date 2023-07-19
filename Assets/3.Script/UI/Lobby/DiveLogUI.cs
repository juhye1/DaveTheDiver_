using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class DiveLogUI : MonoBehaviour
{
    private Sequence sequence;
    private InputKeyUI inputKeyUI;
    private Player_Lobby player;

    private Vector2 home;

    [Header("Dive Log")]
    [SerializeField] private TextMeshProUGUI DiveNo;
    [SerializeField] private Image BiggestFish;
    [SerializeField] private RectTransform DiveLogTransform;

    [Header("Fish Log")]
    [SerializeField] private RectTransform FishLogTransform;
    [SerializeField] private FishSlot[] FishSlot;
    [SerializeField] private Sprite BlankBox;
    [SerializeField] private Sprite FishBox;

    private List<ItemInformation> FishList;

    [Header("Bancho")]
    [SerializeField] private RectTransform BanchoImage;


    private void Awake()
    {
        inputKeyUI = FindObjectOfType<InputKeyUI>();
        player = FindObjectOfType<Player_Lobby>();
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
        UpdateUI();
        DiveLogTransform.DOLocalMoveY(0, 0.7f).SetEase(Ease.OutBounce);
    }

    public void FishLogUIOn()
    {
        DiveLogTransform.localPosition = home;
        DiveLogTransform.gameObject.SetActive(false);
        FishLogTransform.DOLocalMoveY(0, 0.7f).SetEase(Ease.OutBounce).OnComplete(() => inputKeyUI.UIOn(true));
        
    }

    public void OFFUI()
    {
        inputKeyUI.UIOn(false);
        FishLogTransform.localPosition = home;
        FishLogTransform.gameObject.SetActive(false);
        BanchoImage.gameObject.SetActive(true);
        UIManager.Instance.SetBlur(false);
        player.ToBancho(true);
        sequence.Play().OnComplete(() => CompleteSet());
    }

    private void CompleteSet()
    {
        inputKeyUI.UIOn(true);
        BanchoImage.gameObject.SetActive(false);
        player.ToBancho(false);
        player.SwitchActionMapUI(false , Player.EState.Lobby);
    }

    private void UpdateUI()
    {
        FishList = InventoryManager.Instance.LoadItem();

        if (FishList != null)
        {
            for (int i = 0; i < FishList.Count; i++)
            {
                FishSlot[i].gameObject.SetActive(true);
                FishSlot[i].Background.sprite = FishBox;
                FishSlot[i].Init(FishList[i]);
            }
        }


        //리스트 길이 만큼 slot 키고 업데이트하기

    }

}
