using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    //원래 이속 0.5 대쉬 0.7
    public enum EState
    {
        Lobby,
        UnderWater,
        Sushi,
        UI,
        Load
    }

    public enum ESlider
    {
        LoadScene,
        Trash,
        Start
    }


    [SerializeField] protected PlayerSettings settings;
    public Transform UIPosition;

    protected Vector2 cachedMove = Vector2.zero;
    [HideInInspector]
    public Vector3 Point { get;protected set; }
    protected bool pressKey = false;
    public bool PressKey => pressKey;


    protected bool dash = false;
    protected float speed;
    protected bool tired = false;

    protected PlayerInput playerInput;
    protected Animator animator;
    protected BaseInteraction interaction;

    public UIInput InputUI;


    protected readonly int isMove = Animator.StringToHash("isMove");
    protected readonly int isReady = Animator.StringToHash("isReady");
    protected readonly int isDash = Animator.StringToHash("isDash");

    protected InputActionMap lobby;
    protected InputActionMap ui;
    protected InputActionMap sushi;
    protected InputActionMap underWater;

    protected SpriteRenderer spriteRenderer;

    protected Rigidbody2D rigid;


    private UIInput uiInput;
    protected EState state;
    public EState State => state;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        playerInput = GetComponent<PlayerInput>();
        speed = settings.MoveSpeed;

        lobby = playerInput.actions.FindActionMap("Lobby");
        ui = playerInput.actions.FindActionMap("UI");
        sushi = playerInput.actions.FindActionMap("Sushi");
        underWater = playerInput.actions.FindActionMap("UnderWater");
    }

    #region InputSystem
    public void OnMove(InputAction.CallbackContext context)
    {
        cachedMove = context.ReadValue<Vector2>();
        if(context.started)
        {
            switch (State)
            {
                case EState.Lobby:
                    SoundManager.Instance.PlaySE(ESE.Dave_Foot_Lobby);
                    break;
                case EState.Sushi:
                    SoundManager.Instance.PlaySE(ESE.Dave_Foot_Sushi);
                    break;
            }


        }


        // 로비, 스시집

        if (cachedMove.x != 0)
        {
            animator.SetBool(isMove, true);
            if (cachedMove.x < 0)
            {
                bool flip = state == EState.Lobby ? true : false;
                spriteRenderer.flipX = flip;
            }
            else if (cachedMove.x > 0)
            {
                bool flip = state == EState.Lobby ? false : true;
                spriteRenderer.flipX = flip ;
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
        cachedMove = context.ReadValue<Vector2>();

        if (InputUI != null)
        {
            InputUI.MoveUI(cachedMove);

        }
    }

/*    public void OnSpace(InputAction.CallbackContext context)
    {
        //한번 누르는건 여기서 하면되고
        pressKey = context.ReadValue<float>() > 0.1f;
        if (!context.started || State.Equals(EState.Sushi))
            return;

        if (SushiGameManager.Instance.State.Equals(SushiGameManager.EState.Start))
        {
            if(interaction!=null)
            interaction.Perform();
        }
    }*/

/*    protected void Space(bool pressKey)
    {
        //얘는 넘어가는거만 하면 되자너
        if(pressKey&&interaction!=null)
        {
            if(interaction.CanPerform())
            {
                interaction.Perform();

            }
        }
    }*/

    //움직이는거 rigidbody로 통일?
    protected void Move()
    {
        rigid.velocity = cachedMove * speed;
        //Vector3 desiredMovement = cachedMove * transform.right;
        //transform.position += desiredMovement * speed * Time.deltaTime;

        //transform.Translate(Vector2.one*0.1f * cachedMove);
    }

    #endregion


    //UI로만 바꾸는듯?
    public void SwitchActionMapUI(bool isOn, EState state)
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
                case EState.Lobby:
                    lobby.Enable(); this.state = state;  break;
                case EState.Sushi:
                    sushi.Enable(); this.state = state; break;
                case EState.UnderWater:
                    underWater.Enable(); this.state = state; break;
                    
            }
        }
    }

    public void ActionMapDisable()
    {
        playerInput.currentActionMap.Disable();
        rigid.velocity = Vector2.zero;
        state = EState.Load;
        Debug.Log("정지");
    }

    public void ActionMapEnable(EState state)
    {
        rigid.velocity = Vector2.zero;
        playerInput.currentActionMap.Disable();

        switch (state)
        {
            case EState.Lobby:
                lobby.Enable(); this.state = state; break;
            case EState.Sushi:
                sushi.Enable(); this.state = state; break;
            case EState.UnderWater:
                underWater.Enable(); this.state = state; break;

        }
    }

}
