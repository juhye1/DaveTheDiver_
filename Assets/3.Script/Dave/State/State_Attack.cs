using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State_Attack : BaseStateMachine<State_Attack.EState>
{
    public State_Attack(Harpoon harpoon, Player_Arms arms, Animator animator, Player_Underwater player) : 
                    base(harpoon, arms, animator, player)
    {

    }
    public enum EState
    {
        Fire,
        Pull, //작은 물고기 당기는거
        Fail, //아무것도 못 잡은거
        Fight, //큰 물고기 당기는거

    }
    protected override void Init()
    {
        AddState(EState.Pull);
        AddState(EState.Fire);
        AddState(EState.Fail);
        AddState(EState.Fight);
    }

    protected override void OnEnter()
    {
        harpoon.Shoot();
        Debug.Log(State);
        //쏘는건 다 똑같고
        switch (State)
        {
            case EState.Fire:
                break;
            case EState.Pull:
                //animator.SetBool("isPull", true);
                break;
            case EState.Fail:
                animator.SetBool("isFail", true);
                break;
            case EState.Fight:
                //animator.SetBool("isFight", true);
                break;
        }
    }

    protected override void OnTick()
    {

        switch (State)
        {
            case EState.Fire:
                harpoon.Shooting();
                break;

            case EState.Pull:
                CameraManager.Instance.ZoomZoomIn();
                break;
            case EState.Fail:

                CameraManager.Instance.ZoomOut();
                harpoon.Return();
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
        switch (State)
        {
            case EState.Fire:
                if(harpoon.Shooting())
                {
                    //이게 트루면 끝까지 날아간거
                    return EState.Fail;
                }
                break;
                //if 물고기를 잡았다면 return Pull
                //if 허공이라면 return Fail
                //if 큰 물고기를 잡았다면 retun Fight
                //발사랑 돌아오는거랑도 나눠?
            case EState.Pull:
                animator.SetBool("isPull", true);
                break;
            case EState.Fail:
                if(harpoon.Return())
                {
                    animator.SetBool("isFail", false);
                    Debug.Log("끝");
                }

                break;
            case EState.Fight:
                animator.SetBool("isFight", true);
                break;
        }

        return State;
    }

}
