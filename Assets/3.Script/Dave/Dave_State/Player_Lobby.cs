using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Lobby : PlayerInteraction
{
    private void Start()
    {
        state = EState.Lobby;
    }

    public void Ready()
    {
        animator.SetBool(isReady, true);
        ActionMapDisable();
    }

    protected void Space(bool pressKey)
    {
        //얘는 넘어가는거만 하면 되자너
        if (pressKey && interaction != null)
        {
            if (interaction.CanPerform())
            {
                interaction.Perform();

            }
        }
    }

    public void OnLobbySpace(InputAction.CallbackContext context)
    {
        //한번 누르는건 여기서 하면되고
        pressKey = context.ReadValue<float>() > 0.1f;
        if (!context.started)
            return;

        if(interaction!=null)
        {

        }

    }


    //애니메이터
    public void GoToUnderWater()
    {
        GameManager.Instance.LoadScene(GameManager.EScene.UnderWater);
    }

    public void ToBancho(bool bancho)
    {
        animator.SetBool("isToBancho", bancho);
    }
    private void Update()
    {
        Interaction();
    }

    private void FixedUpdate()
    {
        switch (state)
        {
            case EState.Lobby:
                Move();
                Space(pressKey);
                break;
            case EState.UI:
                break;
        }
    }
}
