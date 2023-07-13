using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : Singleton<InventoryManager>
{

    private List<FishInformation> FishList;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        FishList = new List<FishInformation>();
    }
    public void SaveFish(FishInformation fish)
    {
        FishList.Add(fish);
    }

    public void SaveItem()
    {

    }
}
