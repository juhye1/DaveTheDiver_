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
        lobby.Disable();
        sushi.Enable();
    }

    public void OnThrowAway(InputAction.CallbackContext context)
    {
        throwaway = context.ReadValue<float>() > 0.1f;
    }

    public void OnStart(InputAction.CallbackContext context)
    {
        startKey = context.ReadValue<float>() > 0.1f;
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

    public void OnPourTea(InputAction.CallbackContext context)
    {
        pour = context.ReadValue<float>() > 0.1f;

        if(context.started)
        {
            UIManager.Instance.MoveKettle();
        }
        if(context.canceled)
        {
            UIManager.Instance.ScoreOn();
            interaction.ChangeType();
        }
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
                if(interaction.InteractionType.
                    Equals(BaseInteraction.EInteractionType.Tick))
                {PourTea(pour);}
                break;
            case EState.Sushi:
                StartSushi(startKey);
                Move();
                DashGauge(dash);
                ThrowSushi(throwaway);
                break;
        }
    }

    public void EndTired()
    {
        UIManager.Instance.EndTired();
        animator.SetBool(isTired, false);
        speed = settings.MoveSpeed;
    }
}
