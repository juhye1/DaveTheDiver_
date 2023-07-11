using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State_Attack : BaseStateMachine<State_Attack.EState>
{
    public enum EState
    {
        Pull, //작은 물고기 당기는거
        Fail, //아무것도 못 잡은거
        Fight, //큰 물고기 당기는거

    }
    protected override void Init()
    {
        AddState(EState.Pull);
        AddState(EState.Fail);
        AddState(EState.Fight);
    }

    protected override void OnEnter()
    {
        switch(State)
        {
            case EState.Pull:
                animator.SetBool("isPull", true);
                break;
            case EState.Fail:
                animator.SetBool("isFail", true);
                break;
            case EState.Fight:
                animator.SetBool("isFight", true);
                break;
        }
    }

    protected override void OnTick()
    {
        switch(State)
        {
            case EState.Pull:
                CameraManager.Instance.ZoomZoomIn();
                break;
            case EState.Fail:
                CameraManager.Instance.ZoomOut();
                break;
            case EState.Fight:
                CameraManager.Instance.ZoomZoomIn();
                break;
        }
    }

    protected override void OnExit()
    {
        base.OnExit();
    }

    protected override EState CheckTransition()
    {
        return base.CheckTransition();
    }

}
