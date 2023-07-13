using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class InfoUI : MonoBehaviour
{
    [SerializeField] private Image Face;
    [SerializeField] private Star Star;
    [SerializeField] private TextMeshProUGUI Name;
    [SerializeField] private TextMeshProUGUI Rank;
    [SerializeField] private TextMeshProUGUI Weight;


    private Vector2 home = new Vector2(-600, -104);
    private Sequence sequence;


    private void Awake()
    {
        transform.localPosition = home;
        Effect();

    }

    public void InfoOn()
    {
        sequence.Play();
    }


    private void OnDisable()
    {
        transform.localPosition = home;
    }

    private void Effect()
    {
        sequence = DOTween.Sequence().Pause();
        sequence.Append(transform.DOLocalMoveX(-180, 0.5f).SetEase(Ease.InQuart))
                .AppendInterval(1)
                .Append(transform.DOLocalMoveX(home.x, 0.5f).SetEase(Ease.InQuart));
    }
}
