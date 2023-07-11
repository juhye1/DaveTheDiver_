using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Harpoon : MonoBehaviour
{
    [SerializeField]private LineRenderer lineRenderer;
    private Rigidbody2D harpoonRigidbody;
    private Player_Underwater player;
    private Transform harpoonTransform;
    private Vector3 home;

    private float speed = 7;
    private float time = 1;
    private bool isStart = false;

    private void Awake()
    {
        player = FindObjectOfType<Player_Underwater>();
        harpoonTransform = GetComponent<Transform>();
        harpoonRigidbody = GetComponent<Rigidbody2D>();
        lineRenderer.enabled = false;
        home = harpoonTransform.localPosition;
    }

    private void OnEnable()
    {
        //좌클릭하면
    }

    public void Shooting()
    {
        //누른 시간에 비례해서 멀리가나?
        harpoonRigidbody.bodyType = RigidbodyType2D.Dynamic;
        isStart = true;
        lineRenderer.enabled = true;
        harpoonRigidbody.AddForce(transform.right* speed, ForceMode2D.Impulse);
        //이거 끝나면 팔 끄기
    }

    public void Return()
    {
        harpoonRigidbody.bodyType = RigidbodyType2D.Kinematic;
        transform.localPosition = Vector2.MoveTowards(transform.localPosition, home, Time.deltaTime*10);
        if(transform.localPosition.Equals(home))
        {
            lineRenderer.enabled = false;
            player.Return();
        }
    }

    private void Update()
    {
        if(isStart)
        {
            lineRenderer.SetPosition(0, home);
            lineRenderer.SetPosition(1, transform.localPosition);
            if(time<0)
            {
                Return();
            }
            else
            {
                time -= Time.deltaTime; 

            }
        }
    }

}
