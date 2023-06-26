using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortraitData : MonoBehaviour
{
    public Dictionary<EEmotionType, Sprite> PortraitDictionary;
    public Sprite[] CobraPortraits;
    public Sprite[] DavePortraits;

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        PortraitDictionary = new Dictionary<EEmotionType, Sprite>();
        PortraitDictionary.Add(EEmotionType.Normal, CobraPortraits[(int)EEmotionType.Normal]);
        PortraitDictionary.Add(EEmotionType.Nice, CobraPortraits[(int)EEmotionType.Nice]);
        PortraitDictionary.Add(EEmotionType.Smile, CobraPortraits[(int)EEmotionType.Smile]);
    }
}
