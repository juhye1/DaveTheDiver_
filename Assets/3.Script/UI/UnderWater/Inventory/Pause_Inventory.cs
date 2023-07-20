using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class Pause_Inventory : UIInput
{

    [SerializeField] private RectTransform[] Equipment;
    [SerializeField] private RectTransform[] Item;
    [SerializeField] private RectTransform[] Mission;

    private List<RectTransform> InventoryList;


    private void Start()
    {
        num = 0;
        //Init();
    }

    public override void MoveUI(Vector2 dir)
    {

        EDirection edir = direction[dir];

        switch (edir)
        {
            case EDirection.Up:
                num -= 1;
                break;
            case EDirection.Down:
                num += 1;
                break;
        }

        num = Mathf.Clamp(num, 0, 10);
        select.anchoredPosition = Item[num].anchoredPosition;

    }


    public override void CancelUI()
    {
        base.CancelUI();
    }

    public override void Space()
    {
        
    }
}
