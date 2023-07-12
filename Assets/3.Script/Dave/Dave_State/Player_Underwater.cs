using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Underwater : PlayerInteraction
{
    public enum EWaterState
    {
        DiagonalToStraight,
        StraightToDiagonal,
        StraightToStraight,
    }


    private Dictionary<Vector2, EDirection> direction = new Dictionary<Vector2, EDirection>();
    private Player_Arms playerArms;
    [SerializeField] private Harpoon harpoon;

    private float blend = 0;
    private float goal = 0;
    private float angle = 0;
    private float curruentAngle = 0;

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

    private void Start()
    {
        playerArms = GetComponentInChildren<Player_Arms>();
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
            //animator.SetBool("isReady", true);
            MousePosition = Mouse.current.position.ReadValue();
        }
        else
        {
            //animator.SetBool("isReady", false);
            transform.eulerAngles = new Vector3(0, 0, 0);
            //playerArms.OffArms();
        }
        //UIManager.Instance.PowerGaugeOn(PressRightButton);
        
    }

    public void OnLeftButton(InputAction.CallbackContext context)
    {
        PressLeftButton = context.ReadValue<float>() > 0.1f;

        //작살 공격
/*        if (PressLeftButton&&PressRightButton)
        {
            animator.SetBool("isFire", true);
            harpoon.Shooting();
            UIManager.Instance.PowerGaugeOn(false);
        }*/
/*        else
        {
            Debug.Log("돌아와");
            animator.SetBool("isFight", false);
            harpoon.Return();

        }*/

    }

    public void Return()
    {
        animator.SetBool("isFire", false);
        playerArms.OffArms();
        harpoon.gameObject.SetActive(false);

    }
    private void UnderwaterMove()
    {
        curruentAngle = transform.localEulerAngles.z;
        rigid.velocity = cachedMove * 5;


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
            blend = 0;
        }
        animator.SetFloat("Blend", blend);

    }

    private void MoveMousePosition(bool press)
    {
        if (press)
        {
            MousePosition = Mouse.current.position.ReadValue();
            if (MousePosition.x < 700)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
            }
            else
                transform.eulerAngles = new Vector3(0, 0, 0);
            //playerArms.MoveArms();
            //CameraManager.Instance.ZoomIn();
        }
        else
        {
            //CameraManager.Instance.ZoomOut();

        }
    }

    private void Update()
    {
        MoveMousePosition(PressRightButton);

    }

    private void FixedUpdate()
    {
        UnderwaterMove();
    }
}
