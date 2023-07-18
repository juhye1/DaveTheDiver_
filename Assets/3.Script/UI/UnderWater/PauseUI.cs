using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseUI : MonoBehaviour
{
    [SerializeField] GameObject pauseUI;
    [SerializeField] ItemSlot[] itemSlot;

    private List<ItemInformation> itemList;
    //재료랑 물고기랑 통일해도될거같기도..

    private void Start()
    {
        foreach(var dd in itemSlot)
        {
            dd.gameObject.SetActive(false);
        }
        pauseUI.SetActive(false);
        
    }
    //여기다가 하나하나 저장
    public void UIOn(bool isOn)
    {
        UpdateItem();
        pauseUI.SetActive(isOn);
    }

    public void UpdateItem()
    {
        itemList = InventoryManager.Instance.LoadItem();

        if(itemList!=null)
        {
            for (int i = 0; i < itemList.Count; i++)
            {
                itemSlot[i].gameObject.SetActive(true);
                itemSlot[i].Init(itemList[i]);
            }
        }


        //리스트 길이 만큼 slot 키고 업데이트하기

    }
}
