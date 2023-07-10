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
    private float blend = 0;
    private float goal = 0;

    private float angle = 0;
    private float curruentAngle = 0;
    private EDirection currentDirection = EDirection.Zero;
    private EDirection oldDirection = EDirection.Zero;
    private EDirection[] eDirections;
    private EWaterState waterState;

    private void Start()
    {
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
        Debug.Log(currentDirection);

        switch(currentDirection)
        {
            case EDirection.Right:
                angle = 180;
                goal = 2;
                break;
            case EDirection.Left:
                angle = 0;
                goal = 2;
                break;
            case EDirection.Up:
                angle = -90;
                goal = 0;
                break;
            case EDirection.Down:
                angle = -270;
                goal = 0;
                break;
            case EDirection.Zero:
                angle = 0;
                goal = 0;
                break;
            case EDirection.Diagonal:
                if(cachedMove.x>0&&cachedMove.y>0)
                {
                    angle = 135;
                }
                else if(cachedMove.x>0&&cachedMove.y<0)
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


                goal = 1;
                break;
        }
        //그 다음 방향 추가하고

        eDirections[1] = currentDirection;


        //위, 아래는 0
        //왼쪽, 오른쪽은 2
        //대각선은 1

        //대각선 -> 일직선
        if(eDirections[0].Equals(EDirection.Diagonal)&&!eDirections[1].Equals(EDirection.Diagonal))
        {
            waterState = EWaterState.DiagonalToStraight;
        }

        //일직선 -> 대각선
        else if(eDirections[1].Equals(EDirection.Diagonal) && !eDirections[0].Equals(EDirection.Diagonal))
        {
            waterState = EWaterState.StraightToDiagonal;
            goal = 1;
        }
        //일직선 -> 일직선
        else if(!eDirections[0].Equals(EDirection.Diagonal) && !eDirections[1].Equals(EDirection.Diagonal))
        {
            waterState = EWaterState.StraightToStraight;
            switch (eDirections[1])
            {
                case EDirection.Down:
                    blend = 0;
                    break;
                case EDirection.Up:
                    blend = 0;
                    break;
                case EDirection.Right:
                    blend = 2;
                    break;
                case EDirection.Left:
                    blend = 2;
                    break;
                case EDirection.Zero:
                    blend = 0;
                    break;

            }
        }


        oldDirection = currentDirection;

        //Debug.Log(curruentAngle);

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
/*                Debug.Log(currentDirection);
                Debug.Log(angle);
                Debug.Log(curruentAngle);*/
                break;
            case EWaterState.StraightToDiagonal:
                curruentAngle = Mathf.LerpAngle(curruentAngle, angle, Time.deltaTime);
                transform.eulerAngles = new Vector3(0, 0, curruentAngle);
                break;
            case EWaterState.StraightToStraight:
                transform.eulerAngles = new Vector3(0, 0, angle);
                break;
        }


        if (!currentDirection.Equals(EDirection.Zero))
        {
            blend = Mathf.Lerp(blend, goal, Time.deltaTime*0.8f);
        }
        else
        {

            blend = 0;
        }
        animator.SetFloat("Blend", blend);

    }

    private void FixedUpdate()
    {
        UnderwaterMove();
    }
}
