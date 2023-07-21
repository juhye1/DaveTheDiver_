using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RecipeSlot : FishSlot
{
    [Header("Recipe")]
    [SerializeField] private TextMeshProUGUI SushiExplain;
    [SerializeField] private TextMeshProUGUI FishName;
    [SerializeField] public TextMeshProUGUI SushiTotalCount;
    [SerializeField] public TextMeshProUGUI SushiMiddleCount;
    [SerializeField] private Image FishFace;

    public override void Init(ItemInformation info, int i = 0)
    {
        //가운데
        Face.sprite = info.SushiSprite;
        Rank.text = $"Lv.{info.Rank}";

    }

    public void Show(ItemInformation info, int count)
    {
        //오른쪽
        Name.text = info.SushiName;
        FishName.text = info.Name;
        MeatTMP.text = info.Raiting.ToString();
        SushiImage.sprite = info.SushiSprite;
        SushiExplain.text = $"{info.Name}고기로 만든 초밥이다.";
        SushiTotalCount.text = $"1/{count}"; //총 몇마리인지 이거는 나중에
        FishFace.sprite = info.Face;


    }

    public void AddMenu(ItemInformation info, int count)
    {
        Face.sprite = info.Face;
        Name.text = info.SushiName;
        SushiImage.sprite = info.SushiSprite;
        FishName.text = info.Name;
        SushiTotalCount.text = $"1/{count}";

    }


}
