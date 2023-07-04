using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Customer_ThinkingUI : MonoBehaviour
{
    private SpriteRenderer[] spriteRenderers;
    private Sequence sequence;
    private Customer customer;

    private void Awake()
    {
        spriteRenderers = GetComponentsInChildren<SpriteRenderer>();
        customer = GetComponentInParent<Customer>();

    }
    private void OnEnable()
    {
        StartCoroutine(BlinkCo());
    }

    private IEnumerator BlinkCo()
    {
        sequence = DOTween.Sequence().SetAutoKill(false).Pause();

        for(int j=0; j<3; j++)
        {
            for (int i = 0; i < spriteRenderers.Length; i++)
            {
                sequence.Append(spriteRenderers[i].DOFade(1, 0.3f))
                        .Join(spriteRenderers[i].gameObject.transform.DOScale(Vector3.one * 0.5f, 0.3f))
                        .SetDelay(0.2f);

                if (i > 0)
                {
                    sequence.Append(spriteRenderers[i - 1].DOFade(0.5f, 0.2f))
                            .Join(spriteRenderers[i].gameObject.transform.DOScale(Vector3.one * 0.3f, 0.2f));
                }
            }

        }

        sequence.Play();

        yield return sequence.WaitForCompletion();
        //²ô±â
        for (int i = 0; i < spriteRenderers.Length; i++)
        {
            spriteRenderers[i].enabled = false;
        }
        customer.SwitchState(Customer.EState.Order);
    }
}
