using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    //원래 이속 0.5 대쉬 0.7
    public enum EState
    {
        Ground,
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

    private Vector2 cachedMove = Vector2.zero;
    [HideInInspector]
    public Vector3 Point { get;protected set; }
    protected bool pressKey = false;
    protected bool dash = false;
    protected float speed;
    protected bool tired = false;

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

    protected Rigidbody2D rigid;


    private UIInput uiInput;
    protected EState state;

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
    }

    #region InputSystem
    public void OnMove(InputAction.CallbackContext context)
    {
        cachedMove = context.ReadValue<Vector2>();
        animator.SetFloat("MoveX", cachedMove.x);
        animator.SetFloat("MoveY", cachedMove.y);

        //바다

        if (cachedMove.x < 0)
        {
            spriteRenderer.flipX = true;
            //transform.localScale = left;
        }
        else if (cachedMove.x > 0)
        {
            spriteRenderer.flipX = false;
            //transform.localScale = Vector2.one;
        }


        //바다


        //이건 나머지
        /*        if (cachedMove.x != 0)
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
                }*/
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

    public void OnDash(InputAction.CallbackContext context)
    {
        //대시 누르면 빨라지고, 애니메이션 나오고, 옆에 스태미나 나와야함
        //스태미나 없으면 지쳐야함
        dash = context.ReadValue<float>() > 0.1f;

        if (state.Equals(EState.Sushi)&&tired) return;


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
        //Vector3 desiredMovement = cachedMove * transform.right;
        //transform.position += desiredMovement * speed * Time.deltaTime;

        //transform.Translate(Vector2.one*0.1f * cachedMove);
        rigid.velocity = cachedMove * 5;
        if(cachedMove!=Vector2.zero)
        {
            Quaternion target = Quaternion.LookRotation(transform.forward, cachedMove);
            Quaternion rotation = Quaternion.RotateTowards(transform.rotation, target,Time.deltaTime*30);
/*            float d = target.eulerAngles.x;
            float f = target.eulerAngles.y;
            float g = target.eulerAngles.z;
            transform.eulerAngles = new Vector3(d,f,-g);*/
            rigid.MoveRotation(rotation);
        }

        
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
                Debug.Log("스시집");
                break;
        }
    }

}
