using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Harpoon : MonoBehaviour
{
    public enum EState
    {
        Success,
        Fail
    }

    [SerializeField]private LineRenderer lineRenderer;
    [SerializeField] private Transform point;
    [SerializeField] private ParticleSystem bloodParticle;
    private Rigidbody2D harpoonRigidbody;
    private BoxCollider2D boxCollider2D;
    private Transform harpoonTransform;
    private Vector3 home;
    private Fish fish;

    private EState harpoonState;
    public EState HarpoonState => harpoonState;
    private float speed = 10;
    private float time = 1f;
    private bool isHome = false;
    //private bool isStart = false;

    private void Awake()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
        boxCollider2D.enabled = false;
        harpoonTransform = GetComponent<Transform>();
        harpoonRigidbody = GetComponent<Rigidbody2D>();
        lineRenderer.enabled = false;
        home = harpoonTransform.localPosition;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Fish")&& fish == null)
        {
            bloodParticle.Play();
            fish = collision.GetComponent<Fish>();
            fish.Fishing(point);
            harpoonState = EState.Success;
            Debug.Log("헉물고기");
            boxCollider2D.enabled = false;
        }
    }
    private void OnEnable()
    {
        harpoonState = EState.Fail;
        harpoonTransform.localPosition = home;
        harpoonRigidbody.velocity = Vector2.zero;
        //좌클릭하면
    }

    public void Shoot()
    {
        boxCollider2D.enabled = true;
        //누른 시간에 비례해서 멀리가나?
        harpoonRigidbody.bodyType = RigidbodyType2D.Dynamic;
        //isStart = true;
        lineRenderer.enabled = true;
        harpoonRigidbody.AddForce(transform.right * speed, ForceMode2D.Impulse);
        //이거 끝나면 팔 끄기
    }

    public bool Shooting()
    {
        //날아가는중
        Line();
        if (time > 0)
        {
            time -= Time.deltaTime;
            if (harpoonState.Equals(EState.Success))
            {
                harpoonRigidbody.bodyType = RigidbodyType2D.Kinematic;
                return true;
            }
            return false;
        }
        else
        {
            harpoonRigidbody.bodyType = RigidbodyType2D.Kinematic;
            return true; }
    }

    public void Return()
    {

        switch(HarpoonState)
        {
            case EState.Success:
                transform.DOLocalMove(home, 1.5f).SetEase(Ease.InExpo).OnComplete(() => isHome = !isHome);
                break;
            case EState.Fail:
                transform.DOLocalMove(home, 0.5f).SetEase(Ease.InExpo).OnComplete(() => isHome = !isHome);
                break;
        }

    }
    public bool CheckReturn()
    {
        if (isHome)
        {
            lineRenderer.enabled = false;
            if(fish!=null)
            {
                Destroy(fish.gameObject);
                fish = null;

            }
            isHome = !isHome;
            
            return true;
        }
        else
            Line();
        return false;
    }

    private void Line()
    {
        lineRenderer.enabled = true;
        lineRenderer.SetPosition(0, home);
        lineRenderer.SetPosition(1, transform.localPosition);
    }
    private void OnDisable()
    {
        harpoonTransform.localPosition = home;
        time = 1;
    }

}
