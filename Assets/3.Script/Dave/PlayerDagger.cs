using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDagger : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    public void isDagger(bool isDagger)
    {
        animator.SetBool("isDagger", isDagger);
    }

    public void OffDagger()
    {
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        animator.SetBool("isDagger", false);
    }
}
