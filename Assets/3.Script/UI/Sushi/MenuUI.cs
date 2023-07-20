using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class MenuUI : UIBase
{
    [Header("UI")]
    [SerializeField] private RectTransform FirstUI;
    [SerializeField] private RectTransform AddUI;
    [SerializeField] private RectTransform AddSushiUI;

    [Header("Slot")]
    [SerializeField] private RecipeSlot[] RecipeSlot;
    [SerializeField] private RecipeSlot AddSushiSlot;
    private ItemInformation saveInfo;
    private int saveCount;
    private List<ItemInformation> itemList;
    private Dictionary<string, List<ItemInformation>> FishDictionary;
    private void Start()
    {
        foreach (var slot in RecipeSlot)
        {
            slot.gameObject.SetActive(false);
        }
    }
    public void OnFirstUI()
    {
        UIInputManager.Instance.SetInputUI(inputUI, UIInputManager.EState.OnUI);
        background.enabled = true;
        FirstUI.gameObject.SetActive(true);
        FirstUI.DOLocalMoveY(0, 0.5f).SetEase(Ease.OutCubic);
    }


    public void OnAddMenuUI(bool isOn)
    {
        if(isOn)
        {
            UpdateItem();
            FirstUI.gameObject.SetActive(false);

        }
        AddUI.gameObject.SetActive(isOn);
    }

    public void OnAddSushiUI(bool isOn)
    {
        if (isOn)
        {
            AddSushiSlot.AddMenu(saveInfo, saveCount);

        }
        AddSushiUI.gameObject.SetActive(isOn);
    }

    public void AddMenuComplete()
    {

    }


    public override void OFFUI()
    {
        FirstUI.gameObject.SetActive(false);
        AddUI.gameObject.SetActive(false);
    }
    //

    private void UpdateItem()
    {
        FishDictionary = InventoryManager.Instance.LoadDictionary();
        List<string> keys = new List<string>(FishDictionary.Keys);

        //총 개수 곱하기 raiting(고기)
        for (int i = 0; i < keys.Count; i++)
        {
            RecipeSlot[i].gameObject.SetActive(true);

            ItemInformation info = FishDictionary[keys[i]][0];
            int count = FishDictionary[keys[i]].Count;
            info.Raiting *= count;
            
            RecipeSlot[i].Init(info);
            RecipeSlot[i].SushiMiddleCount.text = $"{count}";

        }

        //리스트 길이 만큼 slot 키고 업데이트하기

    }

    public int LoadCount()
    {
        return saveCount;
    }

    public void LoadItemInfo(int num)
    {
        if (itemList==null) return;

        saveCount = FishDictionary[itemList[num].Name].Count;

        RecipeSlot[num].Show(itemList[num], saveCount);
        saveInfo = itemList[num];
    }
}
