using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class Pause_Inventory : UIInput
{
    public enum EState
    {
        Equipment,
        Item,
        Mission
    }
    private int num = 0;
    private EState state = EState.Item;

    [SerializeField] private RectTransform[] Equipment;
    [SerializeField] private RectTransform[] Item;
    [SerializeField] private RectTransform[] Mission;

    private List<RectTransform> InventoryList;


    private void Start()
    {
        Init();
    }

    private void Init()
    {
        InventoryList = new List<RectTransform>();

        foreach (RectTransform rect in Equipment)
        {
            InventoryList.Add(rect);
        }
        foreach (RectTransform rect in Item)
        {
            InventoryList.Add(rect);
        }
        foreach (RectTransform rect in Mission)
        {
            InventoryList.Add(rect);
        }

        //가까운것중에 해당 방향에 있는걸로 이동
        var dd = InventoryList.OrderBy(n => Vector2.Distance(select.position, n.position)).ToList();
    }
    public override void Inventory(Vector2 dir)
    {


        switch (state)
        {
            case EState.Item:
                ItemMove(dir);
                break;
            case EState.Equipment:
                EquipmentMove(dir);
                break;
            case EState.Mission:
                MissionMove(dir);
                break;
        }


    }

    private void ItemMove(Vector2 dir)
    {
        select.sizeDelta = Item[num].sizeDelta;
        EDirection edir = direction[dir];

        switch (edir)
        {
            case EDirection.Up:
                num -= 1;
                break;
            case EDirection.Down:
                num += 1;
                break;
            case EDirection.Left:

                if (num < 4)
                {
                    state = EState.Equipment;
                    num = 0;
                }
                else
                {
                    state = EState.Mission;
                    num = 0;
                }
                break;
        }

        num = Mathf.Clamp(num, 0, 10);
        select.anchoredPosition = Item[num].anchoredPosition;

    }

    private void MissionMove(Vector2 dir)
    {

        EDirection edir = direction[dir];

        switch (edir)
        {
            case EDirection.Up:
                num -= 1;
                if(num<0)
                {
                    state = EState.Equipment;
                }
                break;
            case EDirection.Down:
                num += 1;
                break;
            case EDirection.Right:
                state = EState.Item;
                break;
        }

        num = Mathf.Clamp(num, 0, 2);
        select.anchoredPosition = transforms[num].anchoredPosition;
        select.sizeDelta = Mission[num].sizeDelta;
    }

    private void EquipmentMove(Vector2 dir)
    {
        //0~8
        //9개
        EDirection edir = direction[dir];

        switch (edir)
        {
            case EDirection.Up:
                num -= 1;
                break;
            case EDirection.Down:
                num += 1;
                break;
            case EDirection.Right:
                num++;
                break;
            case EDirection.Left:
                num--;
                break;
        }

        num = Mathf.Clamp(num, 1, 32);
        select.anchoredPosition = transforms[num].anchoredPosition;
        select.sizeDelta = Equipment[num].sizeDelta;
    }
}
