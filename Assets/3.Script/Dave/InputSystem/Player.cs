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
        Sushi,
        UI,
        Load
    }

    enum EInteractionType
    {
        Enter,
        Tick
    }
    [SerializeField] protected PlayerSettings settings;
    private Vector2 cachedMove = Vector2.zero;
    private Vector2 left = new Vector2(-1, 1);
    public Vector3 Point { get;protected set; }
    private bool pressKey = false;

    private PlayerInput playerInput;
    private Animator animator;
    protected BaseInteraction interaction;
    protected BaseInteraction movePointinteraction;

    private readonly int isMove = Animator.StringToHash("isMove");
    private readonly int isReady = Animator.StringToHash("isReady");

    private InputActionMap lobby;
    private InputActionMap ui;
    private UIInput uiInput;
    protected EState state;

    private void Awake()
    {
        state = EState.Ground;
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
        pressKey = context.ReadValue<float>() > 0.1f;
        if (!context.started)
            return;

            if (interaction != null)
            {
                interaction.Perform();
            }

    }

    private void Space(bool pressKey)
    {
        if(pressKey&&interaction!=null)
        {
            if(interaction.CanPerform())
            {
                interaction.Perform();

            }
        }
    }

    private void Move()
    {
        Vector3 desiredMovement = cachedMove * transform.right;
        transform.position += desiredMovement * settings.MoveSpeed * Time.deltaTime;

    }

    #endregion


    private void FixedUpdate()
    {
        switch(state)
        {
            case EState.Ground:
                Move();
                Space(pressKey);
                break;
            case EState.UI:
                break;
        }
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

    public void LoadScene(ELoadScene scene)
    {
        ELoadScene sceneType = scene;
        switch(scene)
        {
            case ELoadScene.UnderWater:
                state = EState.Load;
                animator.SetTrigger(isReady);
                break;
            case ELoadScene.Sushi:
                state = EState.Load;
                animator.SetTrigger(isReady);
                Debug.Log("½º½ÃÁý");
                break;
        }
    }
}
