using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DiveLogSlot : ItemSlot
{
    [SerializeField] private TextMeshProUGUI Depth;
    [SerializeField] private TextMeshProUGUI Time;
    [SerializeField] private TextMeshProUGUI Length;
    [SerializeField] private TextMeshProUGUI Caught;
    [SerializeField] private Star Star;

    public override void Init(ItemInformation info, int i = 0)
    {
        base.Init(info, i);
        Caught.text = i.ToString();
        Length.text = $"{info.Length} cm";
        Star.StarAlpha(info.Raiting);

    }
    //시간 / 깊이 / 총 잡은 물고기 / 
    //물고기 이름, cm, 물고기 얼굴, 별
}
