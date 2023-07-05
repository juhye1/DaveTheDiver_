using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BubbleController : MonoBehaviour
{
    //분노 게이지
    //흔들ㄹㅣㄱㅔ 
    [SerializeField] private Transform angryGauge;
    private Customer customer;
    private Sequence sequence;
    private SpriteMask spriteMask;
    private SpriteRenderer bubbleShape;

    private void Start()
    {
        customer = GetComponentInParent<Customer>();
        bubbleShape = GetComponent<SpriteRenderer>();
        spriteMask = GetComponent<SpriteMask>();

        spriteMask.sprite = bubbleShape.sprite;
    }
    private void OnEnable()
    {
        sequence = DOTween.Sequence().Pause();
        sequence.Append(transform.DOShakePosition(10, new Vector3(0, 0.015f, 0), 3, 0).SetEase(Ease.Linear))
                .Append(angryGauge.DOLocalMoveY(0, 10f))
                .Join(transform.DOShakePosition(10, new Vector3(0, 0.025f, 0), 5, 0).SetEase(Ease.OutCirc));

        sequence.Play();
        sequence.OnComplete(() => ff());
    }

    private void OnDisable()
    {
        sequence.Kill();
    }

    private void ff()
    {
        customer.SwitchState(Customer.EState.Angry);
        //화내기
    }
}
