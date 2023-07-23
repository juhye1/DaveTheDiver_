using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiveDave : MonoBehaviour
{
    private Animator animator;
    private SpriteRenderer DiveSpriterenderer;
    [SerializeField] private SpriteRenderer DaveSpriteRenderer;

    private void Awake()
    {
        DiveSpriterenderer = GetComponent<SpriteRenderer>();
        DiveSpriterenderer.enabled = false;
        DaveSpriteRenderer.enabled = false;
        animator = GetComponent<Animator>();
        StartCoroutine(timerCo());
    }

    public void SetActiveDave()
    {
        DaveSpriteRenderer.enabled = true;
        transform.gameObject.SetActive(false);
    }

    private IEnumerator timerCo()
    {
        WaitForSeconds seconds = new WaitForSeconds(3);

        yield return seconds;
        DiveSpriterenderer.enabled = true;
        animator.SetTrigger("isDive");

    }

}
