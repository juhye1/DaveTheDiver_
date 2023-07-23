using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class Customer_Particle : MonoBehaviour
{
    [SerializeField] private ParticleSystem goldParticle;
    [SerializeField] private ParticleSystem greenParticle;
    [SerializeField] private Transform goldTransform;
    [SerializeField] private TextMeshPro goldText;

    private ParticleSystem heartParticle;
    private MiniMenuUI miniMenuUI;
    private Customer customer;
    private int gold;

    private void Awake()
    {
        heartParticle = GetComponent<ParticleSystem>();
        miniMenuUI = FindObjectOfType<MiniMenuUI>();
        customer = GetComponentInParent<Customer>();
    }

    private void Start()
    {
        int price = miniMenuUI.ReturnPrice(customer.GetKey());
        gold = price;
    }
    private void OnParticleSystemStopped()
    {
        GoldEffect();
        customer.SwitchState(Customer.EState.Good);
    }



    public void HeartParticlePlay()
    {
        heartParticle.Play();
    }

    public void GreenParticlePlay()
    {
        greenParticle.Play();
    }
    private void GoldEffect()
    {
        goldTransform.gameObject.SetActive(true);
        goldText.text = gold.ToString();
        goldTransform.DOLocalMoveY(0.3f, 0.3f).SetEase(Ease.OutBounce).OnComplete(() => 
        goldTransform.gameObject.SetActive(false));
        GoldManager.Instance.UpdateGoldUI(gold);

        heartParticle.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
    }
}
