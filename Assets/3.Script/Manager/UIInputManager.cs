using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UIInputManager : Singleton<UIInputManager>
{
    public enum EState
    {
        EnterUI, OnUI, ExitUI, DisableUIInput
    }
    //private PlayerInput UIInput;
    private UIInput InputUI;
    private Player player;
    private PlayerInput inputsystem;
    [SerializeField] private EState State;
    [SerializeField] private Player.EState playerState;
    private Vector2 cachedMove;
    private InputKeyUI inputKeyUI;
    private InputActionMap sleepActionMap;
    private InputActionMap onActionMap;
    private void Awake()
    {
        State = EState.EnterUI;
        player = FindObjectOfType<Player>();
        inputKeyUI = FindObjectOfType<InputKeyUI>();
        inputsystem = GetComponent<PlayerInput>();
        sleepActionMap = inputsystem.actions.FindActionMap("Sleep");
        onActionMap = inputsystem.actions.FindActionMap("UI");

    }

    public void SetUIState(EState state)
    {
        //이건 나중에 하기(UI 효과 다 나오고 나서 움직이고 싶을때)
        State = state;

        switch (State)
        {
            case EState.ExitUI:
                player.ActionMapEnable(playerState);
                inputKeyUI.UIOn(true);
                InputUI = null;

                switch (playerState)
                {
                    case Player.EState.Sushi:
                        SushiGameManager.Instance.ActiveOpenUI(true);
                        break;


                }
                break;

            case EState.OnUI:
                player.ActionMapDisable();

                switch (playerState)
                {
                    case Player.EState.Sushi:
                        SushiGameManager.Instance.ActiveOpenUI(false);
                        break;


                }
                break;
            case EState.DisableUIInput:
                inputsystem.currentActionMap.Disable();
                sleepActionMap.Enable();
                break;
            case EState.EnterUI:
                inputsystem.currentActionMap.Disable();
                onActionMap.Enable();
                break;


        }



    }

    public void SetInputUI(UIInput input, EState state=EState.EnterUI)
    {
        //이건 한번에 하기
        InputUI = input;

        if(state.Equals(EState.OnUI))
        {
            SetUIState(EState.OnUI);
        }
    }

    public void OnNumberOne(InputAction.CallbackContext context)
    {
        //if (!State.Equals(EState.EnterUI)) return;

        if (context.started)
        {
            UIManager.Instance.SushiMenuUI();
            player.ActionMapDisable();
            State = EState.OnUI;
        }
    }

    public void OnMoveUI(InputAction.CallbackContext context)
    {
        if (!State.Equals(EState.OnUI) || !context.started) return;
        cachedMove = context.ReadValue<Vector2>();
        if (InputUI != null)
        {
            InputUI.MoveUI(cachedMove);

        }

    }

    public void OnCKey(InputAction.CallbackContext context)
    {
        if (!State.Equals(EState.OnUI) || !context.started) return;

        if (InputUI != null)
        {
            InputUI.CancelUI();
            //State = EState.ExitUI;

        }

    }

    public void OnSpace(InputAction.CallbackContext context)
    {
        //if (State.Equals(EState.ExitUI) || !context.started) return;   
        if (!context.started) return;   
        if (InputUI != null)
        {
            InputUI.Space();

        }

    }




}
