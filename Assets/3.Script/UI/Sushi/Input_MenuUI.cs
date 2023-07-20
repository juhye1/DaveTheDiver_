using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Input_MenuUI : UIInput
{
   public enum EState
    {
        EnterUI,
        GotoAddMenu,
        SelectSushi,
        AddSushi
    }
    private List<RectTransform> SlotList;
    private EState state = EState.EnterUI;
    private MenuUI menuUI;
    private void Start()
    {
        num = 0;
        SlotList = new List<RectTransform>();
        menuUI = GetComponent<MenuUI>();
        SlotList.AddRange(transforms);
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

        num = Mathf.Clamp(num, 0, SlotList.Count);
        select.anchoredPosition = transforms[num].anchoredPosition;
    }

    public override void CancelUI()
    {
        throw new System.NotImplementedException();
    }

    public override void Space()
    {
        switch(state)
        {
            case EState.EnterUI:
                menuUI.OnAddMenuUI();
                break;
            case EState.GotoAddMenu:
                break;

            case EState.SelectSushi:
                break;
            case EState.AddSushi:
                break;
                

        }
    }
}
