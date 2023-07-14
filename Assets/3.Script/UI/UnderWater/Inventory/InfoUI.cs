using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class InfoUI : MonoBehaviour
{
    //¾ê´Â ÀÏÈ¸¼º

    [SerializeField] private Image Face;
    [SerializeField] private Star Star;
    [SerializeField] private TextMeshProUGUI Name;
    [SerializeField] private TextMeshProUGUI Rank;
    [SerializeField] private TextMeshProUGUI Weight;

    private Information information;
    private ItemInformation dd;
    private Vector2 home = new Vector2(-600, -104);
    private Sequence sequence;


    private void Awake()
    {
        transform.localPosition = home;
        //Effect();

    }
    public void UpdateUI(Sprite face, string name, float weight, string rank="-", int star=0)
    {
        Face.sprite = face;
        Name.text = name;
        Rank.text = $"Rank<b><color=#487690><size=30>{rank}";
        Weight.text = $"{weight} <color=#487690>kg";
        Star.StarOn(star);

        sequence = DOTween.Sequence().SetDelay(1);
        sequence.Append(transform.DOLocalMoveX(-180, 0.5f).SetEase(Ease.InQuart))
                .AppendInterval(1)
                .Append(transform.DOLocalMoveX(home.x, 0.5f).SetEase(Ease.InQuart));
    }

/*    private void Effect()
    {
        sequence = DOTween.Sequence().Pause().SetDelay(1).SetAutoKill(false);
        sequence.Append(transform.DOLocalMoveX(-180, 0.5f).SetEase(Ease.InQuart))
                .AppendInterval(1)
                .Append(transform.DOLocalMoveX(home.x, 0.5f).SetEase(Ease.InQuart));
    }*/
}
