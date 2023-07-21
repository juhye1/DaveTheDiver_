using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniMenuSlot : ItemSlot
{
    [Header("Sprite")]
    [SerializeField] private Sprite EmptySlot;
    [SerializeField] private Sprite Slot;
    [SerializeField] private Image Background;
    [SerializeField] private GameObject MiniMenuGO;



    private void Awake()
    {
        Background.sprite = EmptySlot;
    }

    //얘는 메뉴 닫으면 업데이트하면될듯?
    public override void Init(ItemInformation info, int i = 0)
    {
        MiniMenuGO.SetActive(true);
        Background.sprite = Slot;
        Face.sprite = info.SushiSprite;
        Rank.text = $"{i}/{i}";
    }
}
