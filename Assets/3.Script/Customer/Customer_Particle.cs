using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer_Particle : MonoBehaviour
{
    private ParticleSystem heartParticle;
    private Customer customer;

    private void Awake()
    {
        heartParticle = GetComponent<ParticleSystem>();
        customer = GetComponentInParent<Customer>();
    }
    private void OnParticleSystemStopped()
    {
        customer.SwitchState(Customer.EState.GoToHome);
    }

    public void ParticlePlay()
    {
        heartParticle.Play();
    }
}
