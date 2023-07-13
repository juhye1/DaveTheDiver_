using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseInformation
{
    public enum EType
    {
        Fish, Item, Weapon //기타 등등 나중에
    }

    public ScriptableObject Information;
    public EType Type;
    public string Name;
    public BaseInformation(ScriptableObject information, EType type, string Name)
    {
        this.Type = type;
        this.Information = information;
        this.Name = Name;
    }

    

    //키(물고기) 넣으면 물고기 리스트가 나온다?
    // 딕셔너리에 어케추가하게????????              
    // 이름을 거기다 또 넣으면 걔 정보가 나오는 딕셔너리가 나온다?
}
