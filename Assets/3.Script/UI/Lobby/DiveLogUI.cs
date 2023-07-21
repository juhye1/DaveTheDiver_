using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;
using DG.Tweening;

public class DiveLogUI : UIBase
{
    private Sequence sequence;
    private Player_Lobby player;

    private Vector2 home;

    [Header("Dive Log")]
    [SerializeField] private RectTransform DiveLogTransform;
    [SerializeField] private DiveLogSlot DiveLogSlot;

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
        FishDictionary = InventoryManager.Instance.LoadDictionary();

        List<string> keys = new List<string>(FishDictionary.Keys);
        List<int> fishLength = new List<int>();

        int totalCount = 0;

        for(int i =0; i<keys.Count; i++)
        {
            FishSlot[i].gameObject.SetActive(true);
            FishSlot[i].Background.sprite = FishBox;

            ItemInformation info = FishDictionary[keys[i]][0];
            fishLength.Add(info.Length);
            int count = FishDictionary[keys[i]].Count;
            totalCount += count;
            info.Raiting *=count;
            FishSlot[i].Init(info);

        }

        int biggestFishLength = fishLength.OrderByDescending(x => x).First();
        Debug.Log(biggestFishLength);

        string key;

        foreach(var k in keys)
        {
            key = FishDictionary[k].FirstOrDefault(x => x.Length == biggestFishLength).Name;
            if(key!=null)
            {
                DiveLogSlot.Init(FishDictionary[key][0], totalCount);
                break;
            }

        }


    }

}
