using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_DiveLogTrigger : BaseObject
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
        diveLogUI = interactionUI.GetComponent<DiveLogUI>();
        CanPerform = !CanPerform;
    }

    public override void Interaction()
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

    private void Update()
    {
        if (movePoint)
        {
            UIManager.Instance.DiveLog();
        }
    }
}
