using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Input_MenuUI : UIInput
{
    private List<RectTransform> SlotList;
    private void Start()
    {
        num = 0;
        SlotList = new List<RectTransform>();
        SlotList.AddRange(transforms);
    }
    public override void MoveUI(Vector2 dir)
    {
        Debug.Log(dir);
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

        num = Mathf.Clamp(num, 0, SlotList.Count);
        select.anchoredPosition = transforms[num].anchoredPosition;
    }

    public override void CancelUI()
    {
        throw new System.NotImplementedException();
    }

    public override void Space()
    {
        throw new System.NotImplementedException();
    }
}
