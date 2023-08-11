using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDagger : MonoBehaviour
{
    [SerializeField]private Animator animator;
    [SerializeField]private ParticleSystem bloodParticle;
    private BoxCollider2D daggerCollider;
    private Fish fish;

    private void Start()
    {
        daggerCollider = GetComponent<BoxCollider2D>();
        daggerCollider.enabled = false;
    }
    public void isDagger(bool isDagger)
    {
        daggerCollider.enabled = true;
        animator.gameObject.SetActive(true);
        animator.SetBool("isDagger", isDagger);
    }

    public void OffDagger()
    {
        if (daggerCollider.isActiveAndEnabled)
        {
            bloodParticle.Clear();
            daggerCollider.enabled = false;
        }
        animator.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Fish") && fish == null)
        {
            bloodParticle.Play();
            Debug.Log("죽어라물고기~!");
            fish = collision.GetComponent<Fish>();
            fish.FishingDagger();
            fish = null;
        }
    }
}
