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
    public Transform UIPosition;

    private Vector2 cachedMove = Vector2.zero;
    private Vector2 left = new Vector2(-1, 1);
    [HideInInspector]
    public Vector3 Point { get;protected set; }
    protected bool pressKey = false;
    protected float speed;

    protected PlayerInput playerInput;
    protected Animator animator;
    protected BaseInteraction interaction;
    protected BaseInteraction movePointinteraction;

    protected readonly int isMove = Animator.StringToHash("isMove");
    protected readonly int isReady = Animator.StringToHash("isReady");
    protected readonly int isDash = Animator.StringToHash("isDash");

    protected InputActionMap lobby;
    protected InputActionMap ui;
    protected InputActionMap sushi;

    protected SpriteRenderer spriteRenderer;



    private UIInput uiInput;
    protected EState state;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        playerInput = GetComponent<PlayerInput>();
        speed = settings.MoveSpeed;

        lobby = playerInput.actions.FindActionMap("Lobby");
        ui = playerInput.actions.FindActionMap("UI");
        sushi = playerInput.actions.FindActionMap("Sushi");
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
                spriteRenderer.flipX = false;
                //transform.localScale = left;
            }
            else if (cachedMove.x > 0)
            {
                spriteRenderer.flipX = true;
                //transform.localScale = Vector2.one;
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

    protected void Space(bool pressKey)
    {
        if(pressKey&&interaction!=null)
        {
            if(interaction.CanPerform())
            {
                interaction.Perform();

            }
        }
    }

    protected void Move()
    {
        Vector3 desiredMovement = cachedMove * transform.right;
        transform.position += desiredMovement * speed * Time.deltaTime;

    }

    #endregion


/*    private void FixedUpdate()
    {
        switch(state)
        {
            case EState.Ground:
                Move();
                Space(pressKey);
                break;
            case EState.UI:
                break;
            case EState.Sushi:
                Move();
                Space(pressKey);
                break;
        }
    }*/

    public void SwitchActionMap(bool isOn, EState state)
    {
        if (isOn)
        {
            playerInput.currentActionMap.Disable();
            ui.Enable();
            this.state = EState.UI;
        }
        else
        {
            ui.Disable();
            switch(state)
            {
                case EState.Ground:
                    lobby.Enable(); this.state = state;  break;
                case EState.Sushi:
                    sushi.Enable(); this.state = state; break;
            }
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
