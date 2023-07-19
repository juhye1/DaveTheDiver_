using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Input_DiveLogUI : UIInput
{
    public enum EState
    {
        DiveLog,
        FishLog,
        Exit


    }

    private EState state = EState.DiveLog;
    private DiveLogUI diveLogUI;

    private void Start()
    {
        diveLogUI = GetComponent<DiveLogUI>();
    }
    public override void MoveUI(Vector2 dir)
    {
        throw new System.NotImplementedException();
    }

    public override void Space()
    {
        switch (state)
        {
            case EState.DiveLog:
                diveLogUI.FishLogUIOn();
                state = EState.FishLog;
                break;
            case EState.FishLog:
                diveLogUI.OFFUI();
                Debug.Log("수조로 보내기");
                LobbyManager.Instance.SetDiveLogCollider(false);
                break;
        }
    }
}
