using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DiverBox_Inventory : UIInput
{
    public enum EState
    {
        Off, On
    }

    private EState state = EState.Off;
    [SerializeField] private RectTransform DiverBox;
    private void Start()
    {
        num = 0;

    }
    public override void MoveUI(Vector2 dir)
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

        num = Mathf.Clamp(num, 0, transforms.Length-1);
        select.anchoredPosition = transforms[num].anchoredPosition;
    }

    public override void CancelUI()
    {
        //base.CancelUI();
        state = EState.Off;
        UpUI(false);
    }

    public override void Space()
    {
        switch(state)
        {
            case EState.Off:
                UIInputManager.Instance.SetUIState(UIInputManager.EState.OnUI);
                UpUI(true);
                state = EState.On;
                break;
            case EState.On:
                break;

        }
    }

    private void UpUI(bool isOn)
    {
        if (isOn)
        {
            DiverBox.gameObject.SetActive(isOn);
            DiverBox.localPosition = new Vector2(0, -1000);
            DiverBox.DOLocalMoveY(0, 1).SetEase(Ease.OutBounce);
        }
        else
        {
            DiverBox.DOLocalMoveY(-1000, 0.5f).OnComplete(() => CompleteSet());
        }
    }

    private void CompleteSet()
    {
        DiverBox.gameObject.SetActive(false);
        UIInputManager.Instance.SetUIState(UIInputManager.EState.ExitUI);
        inputKeyUI.UIOn(true);
    }

}
