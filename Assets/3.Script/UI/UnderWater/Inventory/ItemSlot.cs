using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ItemSlot : MonoBehaviour
{

    public void Init(ItemInformation info)
    {
        Face.sprite = info.Face;
        Name.text = info.Name;
        Rank.text = $"Rank<b><color=#487690><size=30>{info.Rank}";
        Weight.text = $"{info.Weight} <color=#487690>kg";
        Star.StarOn(info.Raiting);
    }



    [SerializeField] private Image Face;
    [SerializeField] private Star Star;
    [SerializeField] private TextMeshProUGUI Name;
    [SerializeField] private TextMeshProUGUI Rank;
    [SerializeField] private TextMeshProUGUI Weight;
}
