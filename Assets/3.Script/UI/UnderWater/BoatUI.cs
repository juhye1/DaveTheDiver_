using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class BoatUI : UIInput
{
    private int num;
    private Sequence sequence;
    private Vector2 hideVector;
    [SerializeField] private RectTransform BoatGO;
    [SerializeField] private RectTransform ExitGO;
    [SerializeField] private Image Background;
    private List<GameObject> UIList;
    private void Start()
    {
        ResetUI();
    }



    public void BoatUIOn()
    {
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
                num = 0;
                break;
            case EDirection.Down:
                num = 1;
                
                break;
        }

        select.anchoredPosition = transforms[num].anchoredPosition;
    }

    private void ResetUI()
    {
        sequence = DOTween.Sequence().Pause();
        sequence.Append(Background.DOFade(0.3f, 1))
            .Append(BoatGO.DOLocalMoveY(-200, 1).SetEase(Ease.OutBounce))
            .Append(ExitGO.DOLocalMoveY(-320, 0.5f).SetEase(Ease.OutBounce));
        hideVector = new Vector2(0, -600);

        UIList = new List<GameObject>();
        UIList.Add(BoatGO.gameObject);
        UIList.Add(ExitGO.gameObject);
        UIList.Add(select.gameObject);
        BoatGO.localPosition = hideVector;
        ExitGO.localPosition = hideVector;

        foreach(GameObject go in UIList)
        {
            go.SetActive(false);
        }

    }
}
