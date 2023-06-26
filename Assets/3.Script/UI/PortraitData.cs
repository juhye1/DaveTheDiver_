using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortraitData : MonoBehaviour
{
    public Dictionary<EEmotionType, Sprite> PortraitDictionary;
    public Sprite[] portraits;

    private void Start()
    {
        Init();
    }

    private void Init()
    {
        PortraitDictionary = new Dictionary<EEmotionType, Sprite>();
        PortraitDictionary.Add(EEmotionType.Normal, portraits[(int)EEmotionType.Normal]);
        PortraitDictionary.Add(EEmotionType.Nice, portraits[(int)EEmotionType.Nice]);
        PortraitDictionary.Add(EEmotionType.Smile, portraits[(int)EEmotionType.Smile]);
    }
}
