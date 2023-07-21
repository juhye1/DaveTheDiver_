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
    [SerializeField] private TextMeshProUGUI subsushiCount;
    private List<RectTransform> SushiGridList;

    private EState state = EState.EnterUI;
    private AddMenuSlot addMenuSlot;
    private MenuUI menuUI;

    private int enterUInum = 0;
    private int selectSushinum = 0;
    private int addSushinum = 0;

    private int saveRecipeSlotnum;
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
                        enterUInum -= 1;
                        break;
                    case EDirection.Down:
                        enterUInum += 1;
                        break;
                }
                break;
                //상하좌우
            case EState.SelectSushi:

                switch (edir)
                {
                    case EDirection.Up:
                        selectSushinum -= 4;
                        break;
                    case EDirection.Down:
                        selectSushinum += 4;
                        break;
                    case EDirection.Right:
                        selectSushinum += 1;
                        break;

                    case EDirection.Left:
                        selectSushinum -= 1;
                        break;
                }

                break;

            case EState.AddSushi:

                switch (edir)
                {
                    case EDirection.Left:
                        addSushinum -= 1;
                        break;
                    case EDirection.Right:
                        addSushinum += 1;
                        break;
                }
                break;

        }
        switch(state)
        {
            case EState.EnterUI:
                enterUInum = Mathf.Clamp(enterUInum, 0, SlotList.Count);
                select.anchoredPosition = transforms[enterUInum].anchoredPosition;
               
                break;

            case EState.SelectSushi:
                selectSushinum = Mathf.Clamp(selectSushinum, 0, sushiTransforms.Length - 1);
                secondSelect.anchoredPosition = sushiTransforms[selectSushinum].anchoredPosition;
                menuUI.LoadItemInfo(selectSushinum);
                menuUI.SetRecipeNum(selectSushinum);
                //여기서 정보 띄우기


                break;
            case EState.AddSushi:
                int count = menuUI.LoadCount();
                //num  = 물고기개수/0 숫자 바꿔야함
                addSushinum = Mathf.Clamp(addSushinum, 0, count);
                sushiCount.text = addSushinum.ToString();
                subsushiCount.text = addSushinum.ToString();
                break;
        }

    }

    public override void CancelUI()
    {
        switch(state)
        {
            case EState.EnterUI:
                base.CancelUI();
                enterUInum = 0;
                selectSushinum = 0;
                addSushinum = 0;
                break;
            case EState.SelectSushi:
                menuUI.OnAddMenuUI(false);
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
                addMenuSlot = transforms[enterUInum].GetComponent<AddMenuSlot>();
                //강조 표시
                menuUI.SelectMenuSlot(addMenuSlot);
                //첫번째 아이템 정보 출력
                menuUI.LoadItemInfo(0);

                state = EState.SelectSushi;
                break;

            case EState.SelectSushi:
                menuUI.OnAddSushiUI(true);

                state = EState.AddSushi;
                break;
            case EState.AddSushi:
                sushiCount.text = addSushinum.ToString();
                subsushiCount.text = addSushinum.ToString();
                menuUI.AddMenuComplete();
                menuUI.LoadItemInfo(0);
                addSushinum = 0;
                menuUI.OnAddSushiUI(false);

                state = EState.SelectSushi;
                //여기서 누르면 왼쪽 메뉴에 추가되게
                break;
                

        }
    }



}
