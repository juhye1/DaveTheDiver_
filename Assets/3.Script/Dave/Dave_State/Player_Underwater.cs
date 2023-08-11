using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.InputSystem;

public class Player_Underwater : PlayerInteraction
{
    public enum EActionState
    {
        Attack, Underwater
    }

    public enum EWaterState
    {
        DiagonalToStraight,
        StraightToDiagonal,
        StraightToStraight,
    }


    private Dictionary<Vector2, EDirection> direction = new Dictionary<Vector2, EDirection>();

    private float blend = 0;
    private float goal = 0;
    private float angle = 0;
    private float curruentAngle = 0;

    public bool Dash => dash;

    private float depth;
    public float Depth => depth;

    [HideInInspector]
    public bool PressRightButton { get; private set; } = false;
    [HideInInspector]
    public bool PressLeftButton { get; private set; } = false;
    [HideInInspector]
    public Vector2 MousePosition;

    private EDirection currentDirection = EDirection.Zero;
    private EDirection oldDirection = EDirection.Zero;
    private EDirection[] eDirections;
    private EWaterState waterState;
    private EActionState actionState = EActionState.Underwater;
    public EActionState ActionState => actionState;

    private void Start()
    {
        SoundManager.Instance.PlayBGM(EBGM.UnderWater);
        state = EState.UnderWater;
        ActionMapEnable(EState.UnderWater);
        AddDirection();
    }
    private void AddDirection()
    {
        eDirections = new EDirection[] { oldDirection, currentDirection };
        //zero로 하나 추가하고
        direction.Add(Vector2.up, EDirection.Up);
        direction.Add(Vector2.down, EDirection.Down);
        direction.Add(Vector2.right, EDirection.Right);
        direction.Add(Vector2.left, EDirection.Left);
        direction.Add(Vector2.zero, EDirection.Zero);
    }

    public void OnUnderWaterMove(InputAction.CallbackContext context)
    {
        cachedMove = context.ReadValue<Vector2>();
        if(context.started)
        {
            SoundManager.Instance.PlaySE(ESE.Dave_Breath);

        }

        animator.SetFloat("MoveX", cachedMove.x);
        animator.SetFloat("MoveY", cachedMove.y);

        //전 방향
        eDirections[0] = oldDirection;


        currentDirection = EDirection.Diagonal;
        foreach (Vector2 dir in direction.Keys)
        {
            if (cachedMove.Equals(dir))
            {
                currentDirection = direction[dir];
                break;
            }
        }
        //현재 방향 업데이트

        goal = 1;
        switch (currentDirection)
        {
            case EDirection.Right:
                angle = 180;
                break;
            case EDirection.Left:
                angle = 0;
                break;
            case EDirection.Up:
                angle = -90;
                break;
            case EDirection.Down:
                angle = -270;
                break;
            case EDirection.Zero:
                angle = 0;
                goal = 0;
                break;

            case EDirection.Diagonal:
                if (cachedMove.x > 0 && cachedMove.y > 0)
                {
                    angle = -135;
                }
                else if (cachedMove.x > 0 && cachedMove.y < 0)
                {
                    angle = -225;
                }
                else if (cachedMove.x < 0 && cachedMove.y < 0)
                {
                    angle = -315;
                }
                else if (cachedMove.x < 0 && cachedMove.y > 0)
                {
                    angle = -45;
                }
                break;
        }
        //그 다음 방향 추가하고

        eDirections[1] = currentDirection;


        //위, 아래는 0
        //왼쪽, 오른쪽은 2
        //대각선은 1

        //대각선 -> 일직선
        if (eDirections[0].Equals(EDirection.Diagonal) && !eDirections[1].Equals(EDirection.Diagonal))
        {
            waterState = EWaterState.DiagonalToStraight;
            goal = 1;
        }

        //일직선 -> 대각선
        else if (eDirections[1].Equals(EDirection.Diagonal) && !eDirections[0].Equals(EDirection.Diagonal))
        {
            waterState = EWaterState.StraightToDiagonal;

            //7시, 1시
            if (cachedMove.x > 0 && cachedMove.y > 0 || cachedMove.x < 0 && cachedMove.y < 0)
            {
                goal = 0;
            }
            //10시, 5시
            else if (cachedMove.x < 0 && cachedMove.y > 0 || cachedMove.x > 0 && cachedMove.y < 0)
            {
                goal = 2;
            }
        }
        //일직선 -> 일직선
        else if (!eDirections[0].Equals(EDirection.Diagonal) && !eDirections[1].Equals(EDirection.Diagonal))
        {
            waterState = EWaterState.StraightToStraight;
            blend = 1;
        }
        oldDirection = currentDirection;


    }

    public void OnRightButton(InputAction.CallbackContext context)
    {
        PressRightButton = context.ReadValue<float>() > 0.1f;
        if (PressRightButton)
        {
            MousePosition = Mouse.current.position.ReadValue();
        }
        
    }

    public void SwitchActionState(EActionState state)
    {
        rigid.velocity = Vector2.zero;
        actionState = state;
    }

    public void OnLeftButton(InputAction.CallbackContext context)
    {
        PressLeftButton = context.ReadValue<float>() > 0.1f;
    }

    public void OnESC(InputAction.CallbackContext context)
    {
        if(context.started)
        {
            switch(state)
            {
                case EState.UnderWater:
                    UIManager.Instance.PaueUIOn(true);
                    break;
                case EState.UI:
                    UIManager.Instance.PaueUIOn(false);
                    break;
            }
            //여기서 액션맵 바꾸고 UI 띄우기
        }
    }
    public void OnDash(InputAction.CallbackContext context)
    {
        //나중에 산소 UI랑 파티클 넣기
        dash = context.ReadValue<float>() > 0.1f;

        if (context.started)
        {
            speed = settings.DashSpeed;
        }

        else if (context.canceled)
        {
            speed = settings.MoveSpeed;
        }
    }


    //애니메이터
    public void EndDagger()
    {
        animator.SetBool("isDagger", false);
        SwitchActionState(EActionState.Underwater);
    }

    public void Recoil(Vector2 dir)
    {
        rigid.AddRelativeForce(dir * -3, ForceMode2D.Impulse);
    }

    protected override void Move()
    {
        curruentAngle = transform.localEulerAngles.z;
        rigid.velocity = cachedMove * speed;


        switch(waterState)
        {
            case EWaterState.DiagonalToStraight:
                curruentAngle = Mathf.LerpAngle(curruentAngle, angle, Time.deltaTime);
                transform.eulerAngles = new Vector3(0, 0, curruentAngle);
                blend = Mathf.Lerp(blend, goal, Time.deltaTime*0.8f);
                break;
            case EWaterState.StraightToDiagonal:
                curruentAngle = Mathf.LerpAngle(curruentAngle, angle, Time.deltaTime);
                transform.eulerAngles = new Vector3(0, 0, curruentAngle);
                blend = Mathf.Lerp(blend, goal, Time.deltaTime * 0.8f);
                break;
            case EWaterState.StraightToStraight:
                transform.eulerAngles = new Vector3(0, 0, angle);
                blend = goal;
                break;
        }


        if (currentDirection.Equals(EDirection.Zero))
        {

            switch (eDirections[0])

            {
                case EDirection.Left:
                    transform.eulerAngles = new Vector3(0, 180, 0);
                    break;
                case EDirection.Right:
                    transform.eulerAngles = new Vector3(0, 0, 0);
                    break;


            }
            blend = 0;
        }


        animator.SetFloat("Blend", blend);

    }

    private void MoveMousePosition()
    {
        bool press = PressRightButton || PressLeftButton ? true : false;
        if (press)
        {
            MousePosition = Mouse.current.position.ReadValue();
            Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
            if (MousePosition.x < pos.x)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
            }
            else
                transform.eulerAngles = new Vector3(0, 0, 0);
        }
    }

    private void Update()
    {
        MoveMousePosition();
        UpdateDepth();

    }

    private void FixedUpdate()
    {
        if (state.Equals(EState.UnderWater))
        {
            switch (actionState)
            {
                case EActionState.Attack:
                    break;
                case EActionState.Underwater:
                    Move();
                    break;

            }
        }
        else
        //UI
        {
            rigid.bodyType = RigidbodyType2D.Kinematic;
            rigid.velocity = Vector2.zero;
            transform.localRotation = Quaternion.identity;
        }

       
    }

    private void UpdateDepth()
    {
        depth = transform.localPosition.y + 20;
    }
}
