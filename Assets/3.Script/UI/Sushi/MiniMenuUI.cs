using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Order
{

    public Sprite SushiSprite;
    public int SushiPrice;
    public Order(Sprite sprite, int price)
    {
        this.SushiSprite = sprite;
        this.SushiPrice = price;
    }
}

public class MiniMenuUI : MonoBehaviour
{
    [SerializeField] private MiniMenuSlot[] MiniSlot;
    [SerializeField] private Sprite Gimchobap;
    [SerializeField] private Sprite GreenTea;
    private List<Sprite> spriteList;
    private List<Order> orderList;
    private int num = 0;
    private Dictionary<Sprite, int> priceDictioanry;

    private void Awake()
    {
        spriteList = new List<Sprite>();
        spriteList.Add(GreenTea);
        spriteList.Add(Gimchobap);
        priceDictioanry = new Dictionary<Sprite, int>();
    }
    public void MiniMenuInit(ItemInformation info, int count)
    {
        MiniSlot[num].Init(info, count);
        spriteList.Add(info.SushiSprite);
        priceDictioanry.Add(info.SushiSprite, info.Price);
        num++;

    }

    public List<Sprite> MenuSushiSprite()
    {
        return spriteList;
    }

    public int ReturnPrice(Sprite sprite)
    {

        if (priceDictioanry != null && priceDictioanry.Count!=0&&priceDictioanry.ContainsKey(sprite))
            return priceDictioanry[sprite];
        else
            return 5;
    }

}
