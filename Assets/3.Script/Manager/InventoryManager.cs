using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : DontDestroySingleton<InventoryManager>
{
    public enum EType
    {
        Fish, Item, Weapon //기타 등등 나중에
    }


    private Dictionary<EType, Dictionary<string, BaseInformation>> InventoryDictionary;
    private Dictionary<string, ItemInformation> ItemDictionary;
    //private Dictionary<string, IngredientInformation> Ingredient;

    private List<ItemInformation> ItemList;
    private BaseInformation Information;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        ItemList = new List<ItemInformation>();
        InventoryDictionary = new Dictionary<EType, Dictionary<string, BaseInformation>>();
        ItemDictionary = new Dictionary<string, ItemInformation>();
        //Ingredient = new Dictionary<string, IngredientInformation>();
    }

    //저장하는건 다 바다에서만
    //불러오는건 바다, 로비, 스시집 다
    //아 그냥 여기서 UI를 불러오고싶은데???? 미래를 버릴까,,,,,,,,?
    public void SaveItem(ItemInformation information)
    {
        Debug.Log("너야?");
        InfoUI infoUI = FindObjectOfType<InfoUI>();
        infoUI.UpdateUI(information.Face, information.Name, information.Weight,
                        information.Rank.ToString(), information.Raiting);
        //ItemDictionary.Add(information.Name, information);
        ItemList.Add(information);
    }

/*    public void SaveIngredient(IngredientInformation information)
    {
        InfoUI infoUI = FindObjectOfType<InfoUI>();
        infoUI.UpdateUI(information.Face, information.Name, information.Weight);
        Ingredient.Add(information.Name, information);
    }
*/
    public List<ItemInformation> LoadItem()
    {
        if (ItemList.Count > 0)
        {
            return ItemList;
        }
        else return null;
        //멀리턴할건데?
    }

}
