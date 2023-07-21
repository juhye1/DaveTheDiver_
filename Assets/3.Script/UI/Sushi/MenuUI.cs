using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class MenuUI : UIBase
{
    [Header("UI")]
    [SerializeField] private RectTransform FirstUI;
    [SerializeField] private RectTransform FirstUIdd;
    [SerializeField] private GameObject SpaceUI;
    [SerializeField] private MiniMenuUI MiniMenuUI;
    [SerializeField] private RectTransform saveRectTransform;

    [SerializeField] private RectTransform AddUI;
    [SerializeField] private RectTransform AddSushiUI;
    [SerializeField] private RectTransform MenuUITransfrom;
    [SerializeField] private RectTransform AddMenuLeftPoint;

    [Header("Slot")]
    [SerializeField] private RecipeSlot[] RecipeSlot;
    [SerializeField] private RecipeSlot AddSushiSlot;

    private AddMenuSlot addMenuSlot;
    private ItemInformation saveInfo;
    private List<ItemInformation> itemList;
    private List<string> Dictionarykeys;
    private Dictionary<string, List<ItemInformation>> FishDictionary;

    private int saveCount;
    private int saveRecipeSlotnum;

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
        RectTransform rect = isOn ? AddMenuLeftPoint : saveRectTransform;
        FirstUIdd.gameObject.SetActive(!isOn);
        if (isOn)
        {
            UpdateItem();
            MenuUITransfrom.SetParent(rect.parent);
        }
        else
        {
            MenuUITransfrom.SetParent(FirstUI);

        }


        MenuUITransfrom.localPosition = rect.localPosition;
        MenuUITransfrom.sizeDelta = rect.sizeDelta;
        MenuUITransfrom.anchoredPosition = rect.anchoredPosition;

        SpaceUI.SetActive(!isOn);
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
        //추가한 메뉴는 빼기
        RecipeSlot[saveRecipeSlotnum].gameObject.SetActive(false);
        //바깥 세상 메뉴판 업데이트하기
        MiniMenuUI.MiniMenuInit(saveInfo, saveCount);
        //뒤 UI 업데이트하기
        addMenuSlot.Init(saveInfo, saveCount);
    }

    public void SelectMenuSlot(AddMenuSlot slot)
    {
        addMenuSlot = slot;
    }

    public void SetRecipeNum(int num)
    {
        saveRecipeSlotnum = num;
    }


    public override void OFFUI()
    {


        background.enabled = false;
        FirstUI.gameObject.SetActive(false);
        AddUI.gameObject.SetActive(false);
    }
    //

    private void UpdateItem()
    {
        //가운데에 주루룩 나오는거
        FishDictionary = InventoryManager.Instance.LoadDictionary();
        Dictionarykeys = new List<string>(FishDictionary.Keys);

        //총 개수 곱하기 raiting(고기)
        for (int i = 0; i < Dictionarykeys.Count; i++)
        {
            RecipeSlot[i].gameObject.SetActive(true);

            ItemInformation info = FishDictionary[Dictionarykeys[i]][0];
            int count = FishDictionary[Dictionarykeys[i]].Count;
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
        //오른쪽에 정보나오는거
        if (FishDictionary == null) return;
        ItemInformation info = FishDictionary[Dictionarykeys[num]][0];

        if (info == null) return;

        string key = info.Name;
        saveCount = FishDictionary[key].Count;

        RecipeSlot[num].Show(info, saveCount);
        saveInfo = info;
    }
}
