using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMenuUI : MonoBehaviour
{
    [SerializeField] private MiniMenuSlot[] MiniSlot;
    [SerializeField] private Sprite Gimchobap;
    [SerializeField] private Sprite GreenTea;
    private List<Sprite> spriteList;
    private int num = 0;

    private void Awake()
    {
        spriteList = new List<Sprite>();
        spriteList.Add(GreenTea);
        spriteList.Add(Gimchobap);
    }
    public void MiniMenuInit(ItemInformation info, int count)
    {
        MiniSlot[num].Init(info, count);
        spriteList.Add(info.SushiSprite);
        num++;

    }

    public List<Sprite> MenuSushiSprite()
    {
        return spriteList;
    }

}
