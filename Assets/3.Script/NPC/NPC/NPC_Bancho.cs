using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Bancho : BaseNPC
{
    private Bancho_Cooking cooking;
    private Sprite cookedSushi;

    private void Start()
    {
        state = Estate.Game;
        cooking = GetComponent<Bancho_Cooking>();
    }
    public override void Game()
    {
        cookedSushi = cooking.CookedSushi();
        if (cookedSushi == null) return;
        SushiGameManager.Instance.OnSushi(cookedSushi);


        //플레이어한테 스시 넘기기
    }

    public override void RandomAnimation()
    {
        throw new System.NotImplementedException();
    }

}
