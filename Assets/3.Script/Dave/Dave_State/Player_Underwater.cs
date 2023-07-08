using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Underwater : PlayerInteraction
{
    public enum EWaterState
    {
        SideToUp,
        UpToSide,
        SideToBottom,
        BottomToSide
    }

    private Dictionary<Vector2, EDirection> direction = new Dictionary<Vector2, EDirection>();
    private Vector2 dd;
    private float blend = 0;
    private EWaterState waterState;
    private EDirection Edirection;
    private EDirection curruentDirection;

    private void Start()
    {
        AddDirection();
    }
    private void AddDirection()
    {
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
        foreach (var dir in direction.Values)
        {
            if (cachedMove.Equals(dir))
            {
                curruentDirection = dir;
                break;
            }
        }




    }
    private void UnderwaterMove()
    {
        Debug.Log(waterState);
        rigid.velocity = cachedMove * 5;

    }
    private void FixedUpdate()
    {
        UnderwaterMove();
    }
}
