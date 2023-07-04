using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer_Particle : MonoBehaviour
{
    private ParticleSystem heartParticle;

    private void Awake()
    {
        heartParticle = GetComponent<ParticleSystem>();
    }
    private void OnParticleSystemStopped()
    {
        Debug.Log("ÇÏÆ®³¡");
    }
}
