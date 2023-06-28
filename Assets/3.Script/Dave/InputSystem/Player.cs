using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;



public class Player : MonoBehaviour
{
    public enum EState
    {
        Ground,
        UnderWater,
        UI
    }

    [SerializeField] private PlayerSettings settings;
    private Vector2 cachedMove = Vector2.zero;
    private Vector2 left = new Vector2(-1, 1);
    public Vector3 Point;

    private PlayerInput playerInput;
    private Animator animator;
    private BaseInteraction interaction;
    private readonly int isMove = Animator.StringToHash("isMove");

    private InputActionMap lobby;
    private InputActionMap ui;
    private UIInput uiInput;
    private EState state;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        playerInput = GetComponent<PlayerInput>();

        lobby = playerInput.actions.FindActionMap("Lobby");
        ui = playerInput.actions.FindActionMap("UI");
    }

    #region InputSystem
    public void OnMove(InputAction.CallbackContext context)
    {
        cachedMove = context.ReadValue<Vector2>();

        if (cachedMove.x != 0)
        {
            animator.SetBool(isMove, true);
            if (cachedMove.x < 0)
            {
                transform.localScale = left;
            }
            else if (cachedMove.x > 0)
            {
                transform.localScale = Vector2.one;
            }
        }
        else
        {
            animator.SetBool(isMove, false);
        }
    }

    public void OnUIMove(InputAction.CallbackContext context)
    {
        if (!context.started)
            return;
        if (uiInput==null)
        {
            uiInput = FindObjectOfType<UIInput>();
        }
        cachedMove = context.ReadValue<Vector2>();
        uiInput.Inventory(cachedMove);
    }

    public void OnSpace(InputAction.CallbackContext context)
    {
        if (!context.started)
            return;
        if(interaction!=null)
        {
            interaction.Perform();
        }
    }

    private void Move()
    {
        Vector3 desiredMovement = cachedMove * transform.right;
        transform.position += desiredMovement * settings.MoveSpeed * Time.deltaTime;

    }

    #endregion

    private void Update()
    {
        Interaction();
    }

    private void FixedUpdate()
    {
        switch(state)
        {
            case EState.Ground:
                Move();
                break;
            case EState.UI:
                break;
        }
    }


    public bool Interaction()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.forward, settings.DetectRange, settings.InteractableMask);
        if (hit.collider != null)
        {
            interaction = hit.transform.GetComponent<BaseInteraction>();
            Point = interaction.Point;
            return true;
        }
        else
        {
            interaction = null;
        }
        return false;

    }

    public void SwitchActionMap(bool isOn)
    {
        if (isOn)
        {
            state = EState.UI;
            lobby.Disable();
            ui.Enable();
        }
        else
        {
            state = EState.Ground;
            lobby.Enable();
            ui.Disable();
        }
    }
}
