using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class bbvkxlzmfgkrltlfj : MonoBehaviour
{
    Transform t;
    Rigidbody2D rigid;
    private void Awake()
    {
        t = GetComponent<Transform>();
        rigid = GetComponent<Rigidbody2D>();
        
    }
    private void Start()
    {
        rigid.AddForce(Vector2.left*0.8f, ForceMode2D.Impulse);

    }
}
