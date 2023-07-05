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
        Tea,
        Good,
        Angry,
        GoToHome
    }
    [SerializeField] private GameObject speechBubble;
    [SerializeField] private GameObject thinkingUI;
    [SerializeField] private Emote_Customer emoteUI;

    private Animator[] animators;
    private SpriteRenderer[] sprites;


    private Transform Goal;
    private Sequence sequence;
    private TextMeshPro tmp;
    private Transform home;
    private SpriteLibrary spriteLibrary;

    private Customer_Particle particle;
    private Bancho_Cooking bancho;
    public SpeechBubble bubble;
    private SpeechBubble spareBubble;
    private SpriteRenderer[] speechBubbleSprites;

    private int isSit = Animator.StringToHash("Sit");
    private int isEat = Animator.StringToHash("Eat");
    private int isWalk = Animator.StringToHash("isWalk");
    private int isGood = Animator.StringToHash("isGood");
    private int isAngry = Animator.StringToHash("isAngry");
    public EOrderType OrderType;
    public void Init(Transform goal, SpeechBubble bubble, SpeechBubble spareBubble,EOrderType ordertype, Transform home,
                    SpriteLibraryAsset libraryAsset)
    {
        this.Goal = goal;
        this.home = home;

        speechBubbleSprites = speechBubble.GetComponentsInChildren<SpriteRenderer>();
        speechBubbleSprites[0].sprite = bubble.Bubble;
        speechBubbleSprites[1].sprite = bubble.Order;
        this.bubble = bubble;
        this.OrderType = ordertype;
        this.spareBubble = spareBubble;

        spriteLibrary = GetComponentInChildren<SpriteLibrary>();
        spriteLibrary.spriteLibraryAsset = libraryAsset;
    }

    private void Start()
    {
        emoteUI = GetComponentInChildren<Emote_Customer>();
        sprites = GetComponentsInChildren<SpriteRenderer>();
        animators = GetComponentsInChildren<Animator>();
        tmp = GetComponentInChildren<TextMeshPro>();
        particle = GetComponentInChildren<Customer_Particle>();
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

    private void Good()
    {
        foreach (Animator ani in animators)
        {
            ani.SetBool(isGood, true);
            ani.SetBool(isEat, false);
        }
    }

    private void Angry()
    {
        foreach (Animator ani in animators)
        {
            ani.SetBool(isAngry, true);
        }
        speechBubble.SetActive(false);
        emoteUI.PlayEmote(EState.Angry);
    }
    public void GoToHome()
    {
        foreach (var sprite in sprites)
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
        thinkingUI.SetActive(false);

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
        emoteUI.PlayEmote(EState.Eat);
        particle.HeartParticlePlay();
        tmp.enabled = true;
        tmp.DOFade(0, 1f);
        //¸»Ç³¼± ²ô°í ÀÌ¸ðÆ¼ÄÜ ¶ç¿ì±â
    }

    private void Tea()
    {
        speechBubble.SetActive(false);
        thinkingUI.SetActive(true);
        particle.GreenParticlePlay();
        speechBubbleSprites[0].sprite = spareBubble.Bubble;
        speechBubbleSprites[1].sprite = spareBubble.Order;

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
            case EState.Tea:
                Tea();
                break;
            case EState.Angry:
                Angry();
                break;
            case EState.Good:
                Good();
                break;
            case EState.GoToHome:
                GoToHome();
                break;

        }
    }

}
