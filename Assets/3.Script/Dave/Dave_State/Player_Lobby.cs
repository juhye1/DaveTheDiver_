using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Lobby : PlayerInteraction
{
    private void Start()
    {
        state = EState.Ground;
    }

    private void FixedUpdate()
    {
        switch (state)
        {
            case EState.Ground:
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
