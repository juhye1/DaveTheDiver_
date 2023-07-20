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
    private List<ItemInformation> itemList;

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


    public void OnAddMenuUI()
    {
        UpdateItem();
        FirstUI.gameObject.SetActive(false);
        AddUI.gameObject.SetActive(true);
    }

    public void OnAddSushiUI()
    {
        AddSushiSlot.AddMenu(saveInfo);
        AddSushiUI.gameObject.SetActive(true);
    }
    public override void OFFUI()
    {
        FirstUI.gameObject.SetActive(false);
        AddUI.gameObject.SetActive(false);
    }
    //

    private void UpdateItem()
    {
        itemList = InventoryManager.Instance.LoadItem();

        if (itemList != null)
        {
            for (int i = 0; i < itemList.Count; i++)
            {
                RecipeSlot[i].gameObject.SetActive(true);
                RecipeSlot[i].Init(itemList[i]);
            }
        }


        //리스트 길이 만큼 slot 키고 업데이트하기

    }

    public void LoadItemInfo(int num)
    {
        RecipeSlot[num].Show(itemList[num]);
        saveInfo = itemList[num];
    }
}
