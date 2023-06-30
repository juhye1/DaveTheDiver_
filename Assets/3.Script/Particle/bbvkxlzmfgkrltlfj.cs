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
/*        Vector3 dd = new Vector3(-0.096f, 0.916f, 0);
        Sequence sequence;
        sequence = DOTween.Sequence();
        sequence.Append(t.DOJump(dd, 0.1f, 1, 1f));*/

    }
}
