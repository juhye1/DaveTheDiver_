using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portrait
{
    public EName Name { get; private set; }
    public EEmotionType EmotionType { get; private set; }
    public Portrait(EName name, EEmotionType type)
    {
        this.Name = name;
        this.EmotionType = type;
    }

    public override bool Equals(object obj)
    {
        var other = obj as Portrait;
        return this.Name == other.Name && this.EmotionType == other.EmotionType;
    }
    public override int GetHashCode()
    {
        return Name.GetHashCode() * 31 + EmotionType.GetHashCode();
    }

}

public class PortraitData : MonoBehaviour
{
    //public Dictionary<EEmotionType, Sprite> dic;
    public Dictionary<Portrait, Sprite> PortraitDictionary;

    public Sprite[] CobraSprites;
    public Sprite[] DaveSprites;

/*    public Dictionary<EEmotionType, Sprite> cobradic;
    public Dictionary<EEmotionType, Sprite> davedic;*/

    private void Awake()
    {
        PortraitDictionary = new Dictionary<Portrait, Sprite>();
        UpdateDictionary(EName.Cobra, CobraSprites);
        UpdateDictionary(EName.Dave, DaveSprites);
    }

/*    private void UpdateDictionary(Dictionary<EEmotionType, Sprite> dictionary, Sprite[] sprites)
    {
        var EmotionTypes = System.Enum.GetValues(typeof(EEmotionType));

        foreach (var value in EmotionTypes)
        {
            var type = (EEmotionType)value;
            if (sprites[(int)value] == null) continue;
            dictionary[type] = sprites[(int)value];
        }
    }*/

    private void UpdateDictionary(EName name, Sprite[] sprites)
    {
        var EmotionTypes = System.Enum.GetValues(typeof(EEmotionType));
        foreach (var value in EmotionTypes)
        {
            if (sprites[(int)value] == null) continue;
            var type = (EEmotionType)value;
            Portrait portrait = new Portrait (name, type);
            PortraitDictionary.Add(portrait, sprites[(int)value]);
        }
    }

    public Sprite LoadPortrait(EName name, EEmotionType emotion)
    {
        Portrait portrait = new Portrait(name, emotion);
        if (PortraitDictionary.ContainsKey(portrait))
            return PortraitDictionary[portrait] ;
        else
            Debug.Log("Å°¾øÀ½"); return null;
    }





}
