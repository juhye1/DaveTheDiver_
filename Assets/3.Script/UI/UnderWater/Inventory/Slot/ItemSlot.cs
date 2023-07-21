using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ItemSlot : MonoBehaviour
{
    [Header("Base Info")]

    [SerializeField] protected Image Face;
    [SerializeField] protected TextMeshProUGUI Name;
    [SerializeField] protected TextMeshProUGUI Rank;

    public virtual void Init(ItemInformation info, int i=0)
    {
        Face.sprite = info.Face;
        Name.text = info.Name;

    }



}
