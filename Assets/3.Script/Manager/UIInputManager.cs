using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UIInputManager : Singleton<UIInputManager>
{
    public enum EState
    {
        EnterUI, OnUI, ExitUI
    }
    //private PlayerInput UIInput;
    private UIInput InputUI;
    private Player player;
    [SerializeField] private EState State;
    [SerializeField] private Player.EState playerState;
    private Vector2 cachedMove;
    private void Awake()
    {
        State = EState.EnterUI;
        player = FindObjectOfType<Player>();
        //UIInput = GetComponent<PlayerInput>();
        //UIInput.currentActionMap.Disable();

    }

    public void SetUIState(EState state)
    {
        State = state;
        if(State.Equals
            (EState.ExitUI)) player.ActionMapEnable(playerState);


    }

    public void SetInputUI(UIInput input)
    {
        InputUI = input;
        player.ActionMapDisable();
    }

    public void OnNumberOne(InputAction.CallbackContext context)
    {
        if (!State.Equals(EState.EnterUI)) return;

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

        Debug.Log("으악머리아파");
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
            InputUI.MoveUI(cachedMove);
            State = EState.ExitUI;

        }

    }

    public void OnSpace(InputAction.CallbackContext context)
    {
        if (!State.Equals(EState.OnUI) || !context.started) return;

        if (InputUI != null)
        {
            InputUI.Space();

        }

    }




}
