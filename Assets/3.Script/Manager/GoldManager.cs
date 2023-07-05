using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GoldManager : Singleton<GoldManager>
{
    private int gold = 100;
    [SerializeField] private TextMeshProUGUI goldTMP;

    public int Gold 
    { 
        get 
        { 
            return gold; }
        set
        {
            if (gold < 0)
            {
                Debug.Log("µ· »¡°£»ö");
            }
        } }
    public void UpdateGoldUI(int _gold)
    {
        gold += _gold;
        goldTMP.text = Gold.ToString();
    }

}
