using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    private float moveSpeed = 0.5f;
    private Vector2 cachedMove = Vector2.zero;
    private Vector2 left = new Vector2(-1, 1);
    private Animator animator;
    private readonly int isMove = Animator.StringToHash("isMove");

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

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

    private void Move()
    {
        Vector3 desiredMovement = cachedMove * transform.right;
        transform.position += desiredMovement * moveSpeed * Time.deltaTime;
    }


    private void FixedUpdate()
    {
        Move();
    }
}
