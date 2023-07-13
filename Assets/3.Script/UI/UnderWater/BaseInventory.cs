using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public abstract class BaseInventory
{
    public BaseInventory()
    {

    }
    //Fish
    protected Image fishFace;
    protected Image fishSushi;

    protected TextMeshProUGUI fishName;
    protected TextMeshProUGUI sushiName;

    protected TextMeshProUGUI fishRank;
    protected TextMeshProUGUI fishPrice;
    protected TextMeshProUGUI fishWeight;

    public abstract void Init();














}
