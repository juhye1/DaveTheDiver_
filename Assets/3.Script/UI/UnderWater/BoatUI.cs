using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class BoatUI : UIBase
{
    //바다에서 로비가는 UI
    public enum EState
    {
        GotoBoat, Cancel
    }
    private Sequence sequence;
    private Vector2 hideVector;
    [SerializeField] private RectTransform BoatGO;
    [SerializeField] private RectTransform ExitGO;
    [SerializeField] private Image Background;
    [SerializeField] protected RectTransform select;
    private List<GameObject> UIList;
    


    private void Start()
    {
        inputUI = GetComponent<UIInput>(); ;
        ResetUI();
    }

    public void BoatUIOn()
    {
        UIInputManager.Instance.SetInputUI(inputUI, UIInputManager.EState.OnUI);
        inputKeyUI.UIOn(false);
        foreach (GameObject go in UIList)
        {
            go.SetActive(true);
        }
        sequence = DOTween.Sequence();
        sequence.Append(Background.DOFade(0.3f, 1))
            .Append(BoatGO.DOLocalMoveY(-200, 0.3f).SetEase(Ease.OutBounce))
            .Append(ExitGO.DOLocalMoveY(-320, 0.3f).SetEase(Ease.OutBounce)).OnComplete(() => OnCompleteSet());
    }


    private void OnCompleteSet()
    {
        select.anchoredPosition = BoatGO.anchoredPosition;
        inputKeyUI.UIOn(true);
        UIInputManager.Instance.SetUIState(UIInputManager.EState.OnUI);
    }

    private void ResetUI()
    {
        sequence = DOTween.Sequence().Pause().SetAutoKill(false);
        sequence.Append(Background.DOFade(0.3f, 1))
            .Append(BoatGO.DOLocalMoveY(-200, 0.5f).SetEase(Ease.OutBounce))
            .Append(ExitGO.DOLocalMoveY(-320, 0.5f).SetEase(Ease.OutBounce)).OnComplete(() => OnCompleteSet());
        hideVector = new Vector2(0, -600);

        UIList = new List<GameObject>();
        UIList.Add(BoatGO.gameObject);
        UIList.Add(ExitGO.gameObject);
        UIList.Add(select.gameObject);

        BoatGO.localPosition = hideVector;
        ExitGO.localPosition = hideVector;
        select.anchoredPosition = BoatGO.anchoredPosition;

        foreach(GameObject go in UIList)
        {
            go.SetActive(false);
        }

    }

    public override void OFFUI()
    {

        BoatGO.localPosition = hideVector;
        ExitGO.localPosition = hideVector;
        select.anchoredPosition = BoatGO.anchoredPosition;

        foreach (GameObject go in UIList)
        {
            go.SetActive(false);
        }
        Background.DOFade(0, 0.5f);
    }
}
