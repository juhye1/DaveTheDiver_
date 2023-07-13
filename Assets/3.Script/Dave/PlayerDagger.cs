using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDagger : MonoBehaviour
{
    [SerializeField]private Animator animator;
    public void isDagger(bool isDagger)
    {
        animator.gameObject.SetActive(true);
        animator.SetBool("isDagger", isDagger);
    }

    public void OffDagger()
    {
        animator.gameObject.SetActive(false);
    }
}
