using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class DiveLogUI : MonoBehaviour
{
    private Sequence sequence;
    private Vector2 home;

    [Header("Dive Log")]
    [SerializeField] private TextMeshProUGUI DiveNo;
    [SerializeField] private Image BiggestFish;
    [SerializeField] private RectTransform DiveLogTransform;

    [Header("Fish Log")]
    [SerializeField] private RectTransform FishLogTransform;


    //바다에 있다가 로비로 왔을때만 떠야되고
    //머 잡아왔는지 떠야함
    //뒤에 블러 켜야하고
    //

    private void Awake()
    {
        sequence = DOTween.Sequence().Pause();
        home = new Vector2(0, -1000);

        DiveLogTransform.position = home;
        FishLogTransform.position = home;
    }

    public void DiveLogUIOn()
    {
        DiveLogTransform.DOLocalMoveY(0, 1).SetEase(Ease.OutBounce);
    }
}
