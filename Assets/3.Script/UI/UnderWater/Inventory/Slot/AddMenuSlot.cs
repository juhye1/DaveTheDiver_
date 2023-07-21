using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AddMenuSlot : ItemSlot
{
    [Header("정보")]
    [SerializeField] private TextMeshProUGUI Tasty;
    [SerializeField] private TextMeshProUGUI Coin;
    [Header("오브젝트")]
    [SerializeField] private GameObject BlankGO;
    [SerializeField] private GameObject AddGO;
    //랭크를 그릇으로?
    public override void Init(ItemInformation info, int amount)
    {
        BlankGO.SetActive(false);
        AddGO.SetActive(true);

        Face.sprite = info.SushiSprite;
        Name.text = info.SushiName;
        Rank.text = $"{amount}/{amount}";
        Tasty.text = info.Tasty.ToString();
        Coin.text = info.Price.ToString();

    }

}
