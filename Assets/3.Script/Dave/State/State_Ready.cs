using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State_Ready : BaseStateMachine<State_Ready.EState>
{
    public enum EState
    {
        Idle,
        Ready,
        Shoot,
        Clear
    }

    protected override void Init()
    {
        AddState(EState.Idle);
        AddState(EState.Ready);
        AddState(EState.Shoot);
        AddState(EState.Clear);
    }
    protected override void OnEnter()
    {
        Debug.Log(State);
        switch (State)
        {
            case EState.Idle:
                animator.SetBool("isReady", false);
                UIManager.Instance.PowerGaugeOn(false);
                break;

            case EState.Ready:
                animator.SetBool("isReady", true);
                UIManager.Instance.PowerGaugeOn(true);
                //파워게이지 UI뜨게 만드는거랑
                //애니메이터
                break;
            case EState.Shoot:
                animator.SetBool("isFire", true);
                UIManager.Instance.PowerGaugeOn(false);
                break;

            case EState.Clear:
                animator.SetBool("isReady", false);
                arms.OffArms();
                UIManager.Instance.PowerGaugeOn(false);
                break;

        }
    }

    protected override void OnTick()
    {
        switch(State)
        {
            case EState.Idle:
                break;
            case EState.Ready:
                CameraManager.Instance.ZoomIn();
                UIManager.Instance.PowerGaugeOn(true);
                //파워게이지 UI뜨게 만드는거랑
                break;
            case EState.Shoot:
                CameraManager.Instance.ZoomZoomIn();
                break;
            case EState.Clear:
                CameraManager.Instance.ZoomOut();
                break;
        }
    }

    protected override void OnExit()
    {
        switch (State)
        {
            case EState.Ready:
                animator.SetBool("isReady", false);

                //파워게이지 끄기
                //애니메이터 바꾸기
                break;
            case EState.Shoot:
                break;
        }
    }

    protected override EState CheckTransition()
    {
        switch (State)
        {
            case EState.Idle:
                //여기를 기본으로
                if (player.PressRightButton && !player.PressLeftButton)
                {
                    return EState.Ready;
                }
                break;
            case EState.Ready:
                //우클릭만 누르고 있다면
                //좌클릭을 눌렀다면
                if(player.PressRightButton&&player.PressLeftButton)
                {
                    return EState.Shoot;
                }
                //둘 다 뗐다면
                else if(!player.PressRightButton &&!player.PressLeftButton)
                {
                    return EState.Clear;
                }
                break;
            case EState.Shoot:
                
                //여기서 옆 스크립트로 이사가기

/*                if(CameraManager.Instance.ZoomZoomIn())
                HasFinished = true;
*/
               //만약에 물고기가 걸렸다면 Fight로 
               //안걸렸다면 Pull로
                break;

        }

        return State;
    }
}
