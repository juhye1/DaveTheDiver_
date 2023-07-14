using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : Singleton<InventoryManager>
{
    //얘는 정보를 담고 있다가 넣어주는 느낌?
    //씬마다 UI가 바뀐다는거 생각하기,,
    //여기서 불러오는게 아니라 UI에서 얘를 불러와야한다는것도 생각하기,,
    //여기서 BaseInformation을 하나 만들고
    //정보가 생길때마다 거기다가 Add를 하는건가?
    //여기는 단순하게 물고기 리스트
    //장비 리스트
    //재료 리스트 이런식으로 나눠놓고
    //info.Add(종류, 정보)
    //하면 그....... 나눠서 정리해주는건 BaseInformation에서 해주나?
    //얘는 매니저인디

    public enum EType
    {
        Fish, Item, Weapon //기타 등등 나중에
    }


    private Dictionary<EType, Dictionary<string, BaseInformation>> InventoryDictionary;
    private Dictionary<string, FishInformation> FishDictionary;
    private Dictionary<string, IngredientInformation> Ingredient;

    private BaseInformation Information;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        InventoryDictionary = new Dictionary<EType, Dictionary<string, BaseInformation>>();
        FishDictionary = new Dictionary<string, FishInformation>();
        Ingredient = new Dictionary<string, IngredientInformation>();
    }

    //저장하는건 다 바다에서만
    //불러오는건 바다, 로비, 스시집 다
    //아 그냥 여기서 UI를 불러오고싶은데???? 미래를 버릴까,,,,,,,,?
    public void SaveFish(FishInformation information)
    {
        InfoUI infoUI = FindObjectOfType<InfoUI>();
        infoUI.UpdateUI(information.Face, information.Name, information.Weight,
                        information.Rank.ToString(), information.Raiting);
        FishDictionary.Add(information.Name, information);
    }

    public void SaveIngredient(IngredientInformation information)
    {
        InfoUI infoUI = FindObjectOfType<InfoUI>();
        infoUI.UpdateUI(information.Face, information.Name, information.Weight);
        Ingredient.Add(information.Name, information);
    }

    public void Load<T>()
    {
        //멀리턴할건데?
    }






/*    public void Save<T>(T information) where T : Information<T>
    {
*//*        information = 
        T info = information;*//*
        switch (information.Type)
        {
            case EType.Fish:
                FishDictionary.Add(information.Name, information.GetInformation());
                break;
            case EType.Item:
                Ingredient.Add(information.Name, );
                break;
        }

        Information = information;*//*

        UpdateInventory();
    }*/

/*    public void UpdateInventory()
    {
*//*
        InventoryDictionary[EType.Fish] = FishDictionary;
        InventoryDictionary[EType.Item] = Ingredient;*//*

    }*/

/*    public BaseInformation Load()
    {
        return Information;
    }*/

}
