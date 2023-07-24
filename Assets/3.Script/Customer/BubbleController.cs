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
    private Vector3 angryHome;

    private void Awake()
    {
        angryHome = new Vector3(0, -0.9f, 0);
        customer = GetComponentInParent<Customer>();
        bubbleShape = GetComponent<SpriteRenderer>();
        spriteMask = GetComponent<SpriteMask>();
        sequence = DOTween.Sequence().Pause().SetAutoKill(false);
        sequence.Append(transform.DOShakePosition(10, new Vector3(0, 0.015f, 0), 3, 0).SetEase(Ease.Linear))
                .Append(angryGauge.DOLocalMoveY(0, 15f))
                .Join(transform.DOShakePosition(15, new Vector3(0, 0.02f, 0), 5, 0).SetEase(Ease.OutCirc));
    }
    private void Start()
    {
        spriteMask.sprite = bubbleShape.sprite;

    }
    private void OnEnable()
    {
        //분노 게이지 올리기
        spriteMask.sprite = bubbleShape.sprite;
        sequence.Restart();
        sequence.Play();
        sequence.OnComplete(() => CustomerAngry());
    }

    private void OnDisable()
    {
        angryGauge.localPosition = angryHome;
        sequence.Pause();
    }

    private void CustomerAngry()
    {
        customer.SwitchState(Customer.EState.Angry);
        //화내기
    }
}
