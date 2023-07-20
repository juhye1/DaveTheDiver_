using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Input_MenuUI : UIInput
{
   public enum EState
    {
        EnterUI,
        AddMenu,
        SelectSushi,
        AddSushi
    }

    [Header("Select")]
    [SerializeField] private RectTransform secondSelect;

    [Header("FirstUI")]
    private List<RectTransform> SlotList;

    [Header("RecipeUI")]
    [SerializeField] private RectTransform sushiGridParent;
    [SerializeField] private RectTransform[] sushiTransforms;
    [SerializeField] private TextMeshProUGUI sushiCount;
    private List<RectTransform> SushiGridList;

    private EState state = EState.EnterUI;
    private MenuUI menuUI;
    private void Start()
    {
        num = 0;
        SlotList = new List<RectTransform>();
        SushiGridList = new List<RectTransform>();
        menuUI = GetComponent<MenuUI>();
        SlotList.AddRange(transforms);
        SushiGridList.AddRange(sushiTransforms);


    }
    public override void MoveUI(Vector2 dir)
    {
        EDirection edir = direction[dir];

        switch(state)
        {
            //수직
            default:
                switch (edir)
                {
                    case EDirection.Up:
                        num -= 1;
                        break;
                    case EDirection.Down:
                        num += 1;
                        break;
                }
                break;
                //상하좌우
            case EState.SelectSushi:

                switch (edir)
                {
                    case EDirection.Up:
                        num -= 4;
                        break;
                    case EDirection.Down:
                        num += 4;
                        break;
                    case EDirection.Right:
                        num += 1;
                        break;

                    case EDirection.Left:
                        num -= 1;
                        break;
                }

                break;

            case EState.AddSushi:

                switch (edir)
                {
                    case EDirection.Left:
                        num -= 1;
                        break;
                    case EDirection.Right:
                        num += 1;
                        break;
                }
                break;

        }
        switch(state)
        {
            case EState.EnterUI:
                num = Mathf.Clamp(num, 0, SlotList.Count);
                select.anchoredPosition = transforms[num].anchoredPosition;
                break;

            case EState.SelectSushi:
                num = Mathf.Clamp(num, 0, sushiTransforms.Length - 1);
                secondSelect.anchoredPosition = sushiTransforms[num].anchoredPosition;
                menuUI.LoadItemInfo(num);
                //여기서 정보 띄우기


                break;
            case EState.AddSushi:
                //num  = 물고기개수/0 숫자 바꿔야함
                num = Mathf.Clamp(num, 0, 10);
                sushiCount.text = num.ToString();
                break;
        }

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
                num = 0;
                menuUI.LoadItemInfo(0);
                state = EState.SelectSushi;
                break;

            case EState.SelectSushi:
                menuUI.OnAddSushiUI();
                num = 0;
                state = EState.AddSushi;
                break;
            case EState.AddSushi:
                num = 0;
                //여기서 누르면 왼쪽 메뉴에 추가되게
                break;
                

        }
    }



}
