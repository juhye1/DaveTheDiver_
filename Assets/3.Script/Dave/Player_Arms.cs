using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Arms : MonoBehaviour
{
    private Player_Underwater player;
    private Animator animator;
    [SerializeField] private Transform arrow;
    [SerializeField] private Transform arm;

    private void Awake()
    {
/*        animator = GetComponentInChildren<Animator>();
        player = GetComponentInParent<Player_Underwater>();
        arm.gameObject.SetActive(false);*/
    }

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
        player = GetComponentInParent<Player_Underwater>();
        arm.gameObject.SetActive(false);
    }
    public void MoveArms()
    {
        arm.gameObject.SetActive(true);
        if (player.MousePosition.x > 700)
        {
            transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, arrow.localEulerAngles.z);
            arm.localRotation = Quaternion.Euler(0, 0, 0);

        }
        else
        {
            transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, arrow.localEulerAngles.z);
            arm.localRotation = Quaternion.Euler(180, 0, 0);
        }
    }

    public Vector2 ArmsDir()
    {
        return arm.right;
    }

    public void FailArms()
    {
        animator.SetBool("isFail", true);
    }

    public void PullArms()
    {
        animator.SetBool("isPull", true);
    }

    public void OffArms()
    {
        if(animator!=null)
        {
             animator.SetBool("isPull", false);
            animator.SetBool("isFail", false);

        }
        arm.gameObject.SetActive(false);

    }
}
