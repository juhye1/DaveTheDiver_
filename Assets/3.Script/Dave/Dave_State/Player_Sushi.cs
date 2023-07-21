using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cysharp.Threading.Tasks;

public class Player_Sushi : PlayerInteraction
{


    private bool pour = false;
    private bool throwaway = false;
    private bool startKey = false;

    private readonly int isTired = Animator.StringToHash("isTired");
    private void Start()
    {
        state = EState.Sushi;
        ActionMapEnable(EState.Sushi);
    }



    public void OnThrowAway(InputAction.CallbackContext context)
    {
        throwaway = context.ReadValue<float>() > 0.1f;
    }

    public void OnStart(InputAction.CallbackContext context)
    {
        startKey = context.ReadValue<float>() > 0.1f;
    }

    public void OnDash(InputAction.CallbackContext context)
    {
        //대시 누르면 빨라지고, 애니메이션 나오고, 옆에 스태미나 나와야함
        //스태미나 없으면 지쳐야함
        dash = context.ReadValue<float>() > 0.1f;

        //if (state.Equals(EState.Sushi) && tired) return;
        if (state.Equals(EState.Sushi) && tired) return;


        if (context.started)
        {
            animator.SetBool(isDash, true);
            speed = settings.DashSpeed;
        }

        else if (context.canceled)
        {
            animator.SetBool(isDash, false);
            speed = settings.MoveSpeed;
        }

    }
    private void StartSushi(bool pressKey)
    {
        bool start = UIManager.Instance.SliderUp(pressKey, ESlider.Start);

        if (start)
        {
            SushiGameManager.Instance.OpenSushi();
        }
    }


    private void ThrowSushi(bool pressKey)
    {
       bool throwsushi = UIManager.Instance.ThrowUI(pressKey);

        if(throwsushi)
        {
            SushiGameManager.Instance.OffSushi();
        }
    }
    private void DashGauge(bool pressKey)
    {
        bool canDash = UIManager.Instance.CheckDash();

        if(canDash)
        {
            UIManager.Instance.DashUI(pressKey);
        }
        else
        {
            animator.SetBool(isTired, true);
            speed = settings.TiredSpeed;
        }
    }

    private void PourTea(bool pressKey)
    {
        //S키 누르면 차 따르기
        if(pressKey)
        {
            interaction.Perform();
        }
    }

    public void OnSushiSpace(InputAction.CallbackContext context)
    {
        //한번 누르는건 여기서 하면되고
        pressKey = context.ReadValue<float>() > 0.1f;
        if (!context.started)
            return;

        if (SushiGameManager.Instance.State.Equals(SushiGameManager.EState.Start))
        {
            Debug.Log("얘가 널인가?");
            if (interaction != null)
                interaction.Perform();
        }
    }

    public void OnPourTea(InputAction.CallbackContext context)
    {

        if (!SushiGameManager.Instance.State.Equals(SushiGameManager.EState.Start)) return;
        pour = context.ReadValue<float>() > 0.1f;

        if (context.started)
        {
            UIManager.Instance.MoveKettle();
        }
        if (context.canceled)
        {
            UIManager.Instance.ScoreOn();
            interaction.ChangeType();
        }
    }

    private void FixedUpdate()
    {
        switch (state)
        {
            case EState.UI:
                if(interaction.InteractionType.Equals(BaseInteraction.EInteractionType.Tick))
                PourTea(pour);
                break;

            case EState.Sushi:
                StartSushi(startKey);
                Interaction();
                Move();
                DashGauge(dash);
                ThrowSushi(throwaway);
                break;
        }
    }
    //애니메이터
    public void EndTired()
    {
        UIManager.Instance.EndTired();
        animator.SetBool(isTired, false);
        speed = settings.MoveSpeed;
    }
}
