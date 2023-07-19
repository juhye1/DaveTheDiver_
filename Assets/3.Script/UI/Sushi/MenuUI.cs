using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class MenuUI : UIBase
{

    [SerializeField] private RectTransform FirstUI;
    //일단 키보드로 내리면 오른쪽에 추가 나오는거 만들고
    // 다 하면 누르면 다음 UI 나오는거 만들고
    // 그 담엔 스시 추가하는거 만들고
    // 그 담엔 스시 추가된걸로 요리하는거 만들기

    public void OnFirstUI()
    {
        UIInputManager.Instance.SetInputUI(inputUI);
        FirstUI.gameObject.SetActive(true);
        FirstUI.DOLocalMoveY(0, 0.5f).SetEase(Ease.OutCubic);
    }

    public override void OFFUI()
    {
        FirstUI.gameObject.SetActive(false);
    }
    //
}
