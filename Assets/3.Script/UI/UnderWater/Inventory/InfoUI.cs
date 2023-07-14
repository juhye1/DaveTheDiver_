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
    private FishInformation dd;
    private Vector2 home = new Vector2(-600, -104);
    private Sequence sequence;


    private void Awake()
    {
        transform.localPosition = home;
        Effect();

    }
    public void InfoOn()
    {
        var dd = InventoryManager.Instance.Load();

        information = InventoryManager.Instance.Load();
        UpdateUI();
        sequence.Play();
    }


    private void UpdateUI()
    {
        Name.text = information.Name;

        switch (information.Type)
        {
            case InventoryManager.EType.Fish:
                Face.sprite = information.Face;
                Rank.text = 
                //info.Information.
                break;
        
        
        }

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
