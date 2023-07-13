using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class InventoryManager : Singleton<InventoryManager>
{
    //얘는 정보를 담고 있다가 넣어주는 느낌?
    //씬마다 UI가 바뀐다는거 생각하기,,
    //여기서 불러오는게 아니라 UI에서 얘를 불러와야한다는것도 생각하기,,
    private Dictionary<BaseInformation.EType, Dictionary<string, BaseInformation>> InventoryDictionary;

    private Dictionary<string, BaseInformation> FishDictionary;
    private Dictionary<string, BaseInformation> ItemDictionary;
    private BaseInformation dd;

    //반환형을 T로 해서,,,, 머,,, 물고기,, 나무,, 이런거 생각해보기

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        InventoryDictionary = new Dictionary<BaseInformation.EType, Dictionary<string, BaseInformation>>();
        FishDictionary = new Dictionary<string, BaseInformation>();
        ItemDictionary = new Dictionary<string, BaseInformation>();
    }
    public void Save<T>(T information) where T : BaseInformation
    {
        switch(information.Type)
        {
            case BaseInformation.EType.Fish:
                FishDictionary.Add(information.Name, information);
                break;
            case BaseInformation.EType.Item:
                ItemDictionary.Add(information.Name, information);
                break;

        }
        dd = information;
        UpdateInventory();
    }

    public void UpdateInventory()
    {
        InventoryDictionary[BaseInformation.EType.Fish] = FishDictionary;
        InventoryDictionary[BaseInformation.EType.Item] = ItemDictionary;

    }

    public BaseInformation Load()
    {
        return dd;
    }

}
