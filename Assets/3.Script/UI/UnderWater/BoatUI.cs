using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class BoatUI : UIInput
{
    public enum EState
    {
        GotoBoat, Cancel
    }
    private int num;
    private Sequence sequence;
    private Vector2 hideVector;
    [SerializeField] private RectTransform BoatGO;
    [SerializeField] private RectTransform ExitGO;
    [SerializeField] private Image Background;

    private Object_WaterToBoat WaterToBoat;
    private List<GameObject> UIList;

    public EState State => state;

    private EState state = EState.GotoBoat;
    private void Start()
    {
        WaterToBoat = FindObjectOfType<Object_WaterToBoat>();
        ResetUI();
    }

    public void BoatUIOn()
    {
        inputKeyUI.UIOn(false);
        foreach (GameObject go in UIList)
        {
            go.SetActive(true);
        }
        sequence.Play();
    }

    public override void MoveUI(Vector2 dir)
    {

        EDirection edir = direction[dir];
        switch (edir)
        {
            case EDirection.Up:
                state = EState.GotoBoat;
                num = 0;
                break;
            case EDirection.Down:
                state = EState.Cancel;
                num = 1;
                break;
        }
        WaterToBoat.MoveCursor(state);
        select.anchoredPosition = transforms[num].anchoredPosition;
    }

    private void OnCompleteSet()
    {
        select.anchoredPosition = BoatGO.anchoredPosition;
        inputKeyUI.UIOn(true);
    }

    private void ResetUI()
    {
        sequence = DOTween.Sequence().Pause();
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
}
