using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State_Attack : BaseStateMachine<State_Attack.EState>
{
    public State_Attack(Harpoon harpoon, Player_Arms arms, Animator animator, Player_Underwater player, PlayerDagger dagger) : 
                    base(harpoon, arms, animator, player, dagger)
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

        InitialState = EState.Fire;
    }

    protected override void OnEnter()
    {
        Debug.Log(State);
        switch (State)
        {
            case EState.Fire:
                player.Recoil(arms.ArmsDir());
                harpoon.Shoot();
                break;
            case EState.Pull:
                harpoon.Return();
                animator.SetBool("isFight", true);
                //Pull은 그냥 땡기는거고 Fight가 바둥바둥하는거
                break;
            case EState.Fail:
                harpoon.Return();
                //arms.FailArms();
                //animator.SetBool("isFail", true);
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
                CameraManager.Instance.ZoomZoomIn(harpoon.transform);
                //harpoon.CheckReturn();
                break;
            case EState.Fail:

                CameraManager.Instance.ZoomOut();
                //harpoon.CheckReturn();
                break;
            case EState.Fight:
                //CameraManager.Instance.ZoomZoomIn();
                break;
        }
    }

    protected override void OnExit()
    {
        switch (State)
        {
            case EState.Fire:
                player.SwitchActionState(Player_Underwater.EActionState.Attack);
                break;
            case EState.Pull:

                break;
            case EState.Fail:

                break;
            case EState.Fight:
                break;
        }
    }

    protected override EState CheckTransition()
    {
        switch (State)
        {
            case EState.Fire:
                if(harpoon.Shooting())
                {
                    switch(harpoon.HarpoonState)
                    {
                        case Harpoon.EState.Success:
                            return EState.Pull;

                        case Harpoon.EState.Fail:
                            return EState.Fail;
                    }

                }
                break;
                //if 물고기를 잡았다면 return Pull
                //if 허공이라면 return Fail
                //if 큰 물고기를 잡았다면 retun Fight
                //발사랑 돌아오는거랑도 나눠?
            case EState.Pull:
                if (harpoon.CheckReturn())
                {
                    HasFinished = !HasFinished;
                }
                //  animator.SetBool("isPull", true);
                break;
            case EState.Fail:
                if(harpoon.CheckReturn())
                {
                    HasFinished = !HasFinished;
                }

                break;
            case EState.Fight:
                //animator.SetBool("isFight", true);
                break;
        }

        return State;
    }

}
