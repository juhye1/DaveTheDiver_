using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Harpoon : MonoBehaviour
{
    [SerializeField]private LineRenderer lineRenderer;
    private Rigidbody2D harpoonRigidbody;
    private Transform harpoonTransform;
    private Vector3 home;

    private float speed = 10;
    private float time = 1f;
    //private bool isStart = false;

    private void Awake()
    {
        harpoonTransform = GetComponent<Transform>();
        harpoonRigidbody = GetComponent<Rigidbody2D>();
        lineRenderer.enabled = false;
        home = harpoonTransform.localPosition;
    }

    private void OnEnable()
    {
        harpoonTransform.localPosition = home;
        harpoonRigidbody.velocity = Vector2.zero;
        //좌클릭하면
    }

    public void Shoot()
    {
        //누른 시간에 비례해서 멀리가나?
        harpoonRigidbody.bodyType = RigidbodyType2D.Dynamic;
        //isStart = true;
        lineRenderer.enabled = true;
        harpoonRigidbody.AddForce(transform.right* speed, ForceMode2D.Impulse);
        //이거 끝나면 팔 끄기
    }

    public bool Shooting()
    {
        Line();
        if (time > 0)
        {
            time -= Time.deltaTime;
            return false;
        }
        else return true;

    }
    public bool Return()
    {
        Line();

        if(transform.localPosition.Equals(home))
        {
            lineRenderer.enabled = false;
            return true;
        }
        else
        {
            harpoonRigidbody.bodyType = RigidbodyType2D.Kinematic;
            transform.localPosition = Vector2.MoveTowards(transform.localPosition, home, Time.deltaTime * 10);
        }
        return false;
    }

    private void Line()
    {
        lineRenderer.SetPosition(0, home);
        lineRenderer.SetPosition(1, transform.localPosition);
    }
    private void OnDisable()
    {
        harpoonTransform.localPosition = home;
        time = 1;
    }

}
