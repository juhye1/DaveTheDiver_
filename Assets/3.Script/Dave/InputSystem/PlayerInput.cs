using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private PlayerSettings settings;
    private Vector2 cachedMove = Vector2.zero;
    private Vector2 left = new Vector2(-1, 1);
    public Vector3 Point;

    private InputAction inputAction;
    private Animator animator;
    private BaseInteraction interaction;
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

    private void Update()
    {
        Interaction();
    }

    private void FixedUpdate()
    {
        Move();
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

}
