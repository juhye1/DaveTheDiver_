using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Lobby : PlayerInteraction
{
    private void Start()
    {
        state = EState.Lobby;
    }

    public void Ready()
    {
        animator.SetBool(isReady, true);
        SwitchActionMap(true, EState.UI);
    }
    //애니메이터
    public void GoToUnderWater()
    {
        GameManager.Instance.LoadScene(GameManager.EScene.UnderWater);
    }


    private void FixedUpdate()
    {
        switch (state)
        {
            case EState.Lobby:
                Move();
                Space(pressKey);
                break;
            case EState.UI:
                break;
            case EState.Sushi:
                Move();
                Space(pressKey);
                break;
        }
    }
}
