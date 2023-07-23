using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Input_BoatUI : UIInput
{
    public enum EState
    {
        GotoBoat, Cancel
    }

    private Player_Underwater player;

    private EState state = EState.GotoBoat;

    public EState State => state;

    private void Start()
    {
        player = FindObjectOfType<Player_Underwater>();    }
    public override void MoveUI(Vector2 dir)
    {

        EDirection edir = direction[dir];
        switch (edir)
        {
            case EDirection.Up:
                state = EState.GotoBoat;
                num = 0;
                break;
            case EDirection.Down:
                state = EState.Cancel;
                num = 1;
                break;
        }
        select.localPosition = transforms[num].localPosition;

    }

    public override void Space()
    {
        switch(state)
        {
            case EState.GotoBoat:
                GameManager.Instance.LoadScene(GameManager.EScene.UnderWaterToLobby);
                break;

            case EState.Cancel:
                player.transform.DOLocalMoveY(6f, 0.5f).OnComplete(() => CancelUI()
                 );
                Debug.Log("UI²¨");
                break;
        }
    }
}
