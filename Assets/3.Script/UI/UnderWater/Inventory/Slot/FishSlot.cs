using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class FishSlot : ItemSlot
{
    [Header("Base Info")]
    [SerializeField] private Image SushiImage;
    [SerializeField] private TextMeshProUGUI CoinTMP;
    [SerializeField] private TextMeshProUGUI MeatTMP;
    [SerializeField] private GameObject SlotGO;
    public Image Background;

    public override void Init(ItemInformation info)
    {
        SlotGO.SetActive(true);
        base.Init(info);
        SushiImage.sprite = info.SushiSprite;
        CoinTMP.text = info.Price.ToString();
        Rank.text = $"Rank<b><color=#A3F9FF><size=30>{info.Rank}";
        MeatTMP.text = info.Raiting.ToString();
    }

}
