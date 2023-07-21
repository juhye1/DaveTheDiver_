using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Input_MenuUI : UIInput
{
   public enum EState
    {
        EnterUI,
        SelectSushi,
        AddSushi,
        AddComplete
    }

    [Header("Select")]
    [SerializeField] private RectTransform secondSelect;
    [SerializeField] private RectTransform selectedSlot;

    [Header("FirstUI")]
    private List<RectTransform> SlotList;


    [Header("RecipeUI")]
    [SerializeField] private RectTransform sushiGridParent;
    [SerializeField] private RectTransform[] sushiTransforms;
    [SerializeField] private TextMeshProUGUI sushiCount;
    private List<RectTransform> SushiGridList;

    private EState state = EState.EnterUI;
    private AddMenuSlot addMenuSlot;
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
                int count = menuUI.LoadCount();
                //num  = 물고기개수/0 숫자 바꿔야함
                num = Mathf.Clamp(num, 0, count+1);
                sushiCount.text = num.ToString();
                break;
        }

    }

    public override void CancelUI()
    {
        switch(state)
        {
            case EState.EnterUI:
                //base.CancelUI();
                num = 0;
                break;
            case EState.SelectSushi:
                menuUI.OnAddMenuUI(false);
                num = 0;
                //뒤로가기
                state = EState.EnterUI;
                break;
            case EState.AddSushi:
                menuUI.OnAddSushiUI(false);
                //얘도 뒤로가기
                state = EState.SelectSushi;
                break;


        }
    }

    public override void Space()
    {
        switch(state)
        {
            case EState.EnterUI:
                //UI 키기
                menuUI.OnAddMenuUI(true);
                //슬롯 선택
                addMenuSlot = transforms[num].GetComponent<AddMenuSlot>();
                //강조 표시
                selectedSlot.anchoredPosition = transforms[num].anchoredPosition;
                menuUI.SelectMenuSlot(addMenuSlot);
                num = 0;
                //첫번째 아이템 정보 출력
                menuUI.LoadItemInfo(0);

                state = EState.SelectSushi;
                break;

            case EState.SelectSushi:
                menuUI.OnAddSushiUI(true);
                num = 0;

                state = EState.AddSushi;
                break;
            case EState.AddSushi:
                num = 0;

                state = EState.AddComplete;
                //여기서 누르면 왼쪽 메뉴에 추가되게
                break;
            case EState.AddComplete:
                menuUI.OnAddMenuUI(false);
                menuUI.AddMenuComplete();

                state = EState.AddSushi;
                break;
                

        }
    }



}
