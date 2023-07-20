using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class DiveLogUI : UIBase
{
    private Sequence sequence;
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
    private Dictionary<string, List<ItemInformation>> FishDictionary;

    [Header("Bancho")]
    [SerializeField] private RectTransform BanchoImage;


    private void Start()
    {
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
        UIInputManager.Instance.SetInputUI(inputUI);
        UIInputManager.Instance.SetUIState(UIInputManager.EState.OnUI);
        UpdateUI();
        DiveLogTransform.DOLocalMoveY(0, 0.7f).SetEase(Ease.OutBounce);
    }

    public void FishLogUIOn()
    {

        DiveLogTransform.localPosition = home;
        DiveLogTransform.gameObject.SetActive(false);
        FishLogTransform.DOLocalMoveY(0, 0.7f).SetEase(Ease.OutBounce).OnComplete(() => inputKeyUI.UIOn(true));

    }

    public override void OFFUI()
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
        UIInputManager.Instance.SetUIState(UIInputManager.EState.ExitUI);
    }

    private void UpdateUI()
    {
        //FishList = InventoryManager.Instance.LoadItem();
        FishDictionary = InventoryManager.Instance.LoadDictionary();


        List<string> keys = new List<string>(FishDictionary.Keys);

        //총 개수 곱하기 raiting
        for(int i =0; i<keys.Count; i++)
        {
            FishSlot[i].gameObject.SetActive(true);
            FishSlot[i].Background.sprite = FishBox;

            ItemInformation info = FishDictionary[keys[i]][0];
            int count = FishDictionary[keys[i]].Count;
            info.Raiting *=count;
            FishSlot[i].Init(info);

        }

/*
        if (FishList != null)
        {
            for (int i = 0; i < FishList.Count; i++)
            {
                FishSlot[i].gameObject.SetActive(true);
                FishSlot[i].Background.sprite = FishBox;
                FishSlot[i].Init(FishList[i]);
            }
        }*/


        //리스트 길이 만큼 slot 키고 업데이트하기

    }

}
