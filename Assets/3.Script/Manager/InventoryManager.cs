using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : DontDestroySingleton<InventoryManager>
{
    public enum EType
    {
        Fish, Item, Weapon //기타 등등 나중에
    }


    private Dictionary<string, ItemInformation> ItemDictionary;
    //private Dictionary<string, IngredientInformation> Ingredient;

    private List<ItemInformation> ItemList;
    private BaseInformation Information;

    private Dictionary<string, List<ItemInformation>> FishDictionary;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        ItemList = new List<ItemInformation>();
        FishDictionary = new Dictionary<string, List<ItemInformation>>();
        //Ingredient = new Dictionary<string, IngredientInformation>();
    }

    public void SaveItem(ItemInformation information)
    {
        InfoUI infoUI = FindObjectOfType<InfoUI>();
        infoUI.UpdateUI(information.Face, information.Name, information.Weight,
                        information.Rank.ToString(), information.Raiting);
        //새로운 물고기
        if(!FishDictionary.ContainsKey(information.Name))
        {
            //여기서 New! 떠도 좋을듯??
            List<ItemInformation> list = new List<ItemInformation>();
            list.Add(information);
            FishDictionary.Add(information.Name, list);
        }
        else
        {
            FishDictionary[information.Name].Add(information);
            //이렇게하고 List길이를 받으면~~~~~~~~~~~~~~총개수~~~~~~~~~~~~~~~~~~
        }

        //ItemDictionary.Add(information.Name, information);
        ItemList.Add(information);
    }
    public List<ItemInformation> LoadItem()
    {
        if (ItemList.Count > 0)
        {
            return ItemList;
        }
        else return null;
        //멀리턴할건데?
    }

    public Dictionary<string, List<ItemInformation>> LoadDictionary()
    {
        return FishDictionary;
    }
}
