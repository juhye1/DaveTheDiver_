using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cysharp.Threading.Tasks;

public class Player_Sushi : PlayerInteraction
{
    private bool dash = false;
    private bool tired = false;
    private bool pour = false;
    private Spawner spawner;

    private readonly int isTired = Animator.StringToHash("isTired");
    private void Start()
    {
        spawner = FindObjectOfType<Spawner>();
        state = EState.Sushi;
        lobby.Disable();
        sushi.Enable();
    }
    public void OnDash(InputAction.CallbackContext context)
    {
        //대시 누르면 빨라지고, 애니메이션 나오고, 옆에 스태미나 나와야함
        //스태미나 없으면 지쳐야함
        dash = context.ReadValue<float>() > 0.1f;
        if (tired) return;
        

        if (context.started)
        {
            animator.SetBool(isDash, true);
            speed = settings.DashSpeed;
        }

        else if(context.canceled)
        {
            animator.SetBool(isDash, false);
            speed = settings.MoveSpeed;
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
        if(pressKey)
        {
            
            spawner.UniWait().Forget();

        }
    }

    public void OnPourTea(InputAction.CallbackContext context)
    {
        pour = context.ReadValue<float>() > 0.1f;
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
                PourTea(pour);
                break;
            case EState.Sushi:
                Move();
                DashGauge(dash);
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
