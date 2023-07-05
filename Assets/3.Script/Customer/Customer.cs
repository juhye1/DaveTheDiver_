using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.U2D.Animation;
using TMPro;
using DG.Tweening;
public class Customer : MonoBehaviour
{
    public enum EOrderType
    {
        Sushi,
        Tea
    }

    public enum EState
    {
        MoveToChair,
        SitChair,
        Order,
        Eat,
        GoToHome
    }
    [SerializeField] private GameObject speechBubble;
    [SerializeField] private GameObject thinkingUI;
    [SerializeField] private GameObject emoteUI;

    private Animator[] animators;
    private SpriteRenderer[] sprites;

    private Transform Goal;
    private Sequence sequence;
    private Customer_Particle heartParticle;
    private TextMeshPro tmp;
    private Transform home;
    private SpriteLibrary spriteLibrary;

    private Bancho_Cooking bancho;
    public SpeechBubble bubble;
    private bool sit;

    private int isSit = Animator.StringToHash("Sit");
    private int isEat = Animator.StringToHash("Eat");
    private int isWalk = Animator.StringToHash("isWalk");
    public EOrderType OrderType;
    public void Init(Transform goal, SpeechBubble bubble, EOrderType ordertype, Transform home,
                    SpriteLibraryAsset libraryAsset)
    {
        this.Goal = goal;
        this.home = home;

        SpriteRenderer[] speechbubble = speechBubble.GetComponentsInChildren<SpriteRenderer>();
        speechbubble[0].sprite = bubble.Bubble;
        speechbubble[1].sprite = bubble.Order;
        this.bubble = bubble;
        this.OrderType = ordertype;

        spriteLibrary = GetComponentInChildren<SpriteLibrary>();
        spriteLibrary.spriteLibraryAsset = libraryAsset;
    }

    private void Start()
    {

        sprites = GetComponentsInChildren<SpriteRenderer>();
        animators = GetComponentsInChildren<Animator>();
        tmp = GetComponentInChildren<TextMeshPro>();
        heartParticle = GetComponentInChildren<Customer_Particle>();
        bancho = FindObjectOfType<Bancho_Cooking>();
        SwitchState(EState.MoveToChair);
        
    }

    private void MoveToChair()
    {
        float distance = transform.position.x - Goal.position.x;
        distance = Mathf.Abs(distance);
        float duration = distance / 1.4f;
        sequence = DOTween.Sequence();
        sequence.Append(transform.DOLocalMoveX(Goal.position.x, duration).SetEase(Ease.Linear).OnComplete(() =>
                                                SitChair()));
    }

    private void GoToHome()
    {
        foreach(var sprite in sprites)
        {
            sprite.flipX = true;
        }
        foreach (Animator ani in animators)
        {
            ani.SetBool(isWalk, true);
            ani.SetBool(isEat, false);
        }

        transform.DOLocalMove(home.position, 5);
    }

    private void SitChair()
    {
        foreach(Animator ani in animators)
        {
            ani.SetBool(isSit, true);
        }
        thinkingUI.SetActive(true);

    }

    public void CustomerOrder()
    {
        speechBubble.SetActive(true);
        speechBubble.transform.DOShakePosition(10, new Vector3(0, 0.02f, 0), 3,0).SetEase(Ease.Linear);

        if (OrderType.Equals(EOrderType.Tea)) return;

        bancho.Order(bubble.Order);
    }

    private void Eat()
    {
        foreach (Animator ani in animators)
        {
            ani.SetBool(isEat, true);
            ani.SetBool(isSit, false);
        }

        speechBubble.SetActive(false);
        emoteUI.SetActive(true);
        heartParticle.ParticlePlay();
        tmp.enabled = true;
        tmp.DOFade(0, 1f);
        //¸»Ç³¼± ²ô°í ÀÌ¸ðÆ¼ÄÜ ¶ç¿ì±â
    }

    public void SwitchState(EState state)
    {
        switch(state)
        {
            case EState.MoveToChair:
                MoveToChair();
                break;
            case EState.SitChair:
                SitChair();
                break;
            case EState.Order:
                CustomerOrder();
                break;
            case EState.Eat:
                Eat();
                break;
            case EState.GoToHome:
                GoToHome();
                break;

        }
    }

}
