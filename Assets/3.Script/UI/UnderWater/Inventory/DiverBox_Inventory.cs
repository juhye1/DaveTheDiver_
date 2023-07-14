using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiverBox_Inventory : UIInput
{
    private int num;
    private void Start()
    {
        num = 1;
        transforms = GetComponentsInChildren<RectTransform>();

    }
    public override void Inventory(Vector2 dir)
    {
        EDirection edir = direction[dir];

        switch (edir)
        {
            case EDirection.Up:
                num -= 8;
                break;
            case EDirection.Down:
                num += 8;
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
    }
}
