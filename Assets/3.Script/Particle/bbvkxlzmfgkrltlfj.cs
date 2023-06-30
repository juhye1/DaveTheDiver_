using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bbvkxlzmfgkrltlfj : MonoBehaviour
{
    private ParticleSystem dd;
    [SerializeField] private ParticleSystem mm;

    private void Awake()
    {
        dd = GetComponent<ParticleSystem>();
    }
    private void OnParticleCollision(GameObject other)
    {
        Debug.Log("´ê¾ÒÀ½");
        mm.Play();
        
    }
}
