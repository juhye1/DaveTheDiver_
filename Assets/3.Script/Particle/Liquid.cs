using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Liquid : MonoBehaviour
{
    public Rigidbody2D rigid;
    private CircleCollider2D circleCollider;
    private void Awake()
    {
        circleCollider = GetComponent<CircleCollider2D>();
        rigid = GetComponent<Rigidbody2D>();
        circleCollider.isTrigger = true;
        
    }

    private void OnEnable()
    {
        rigid.bodyType = RigidbodyType2D.Dynamic;
        rigid.AddForce(Vector2.left * 0.8f, ForceMode2D.Impulse);
        circleCollider.isTrigger = false;
    }

    private void OnDisable()
    {
        rigid.bodyType = RigidbodyType2D.Kinematic;
        circleCollider.isTrigger = true;
    }
}
