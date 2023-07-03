using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
public class Customer : MonoBehaviour
{
    public enum EOrderType
    {
        Sushi,
        Tea
    }
    private SpriteRenderer Face;
    private Transform Goal;
    private Sequence sequence;
    [SerializeField] private GameObject speechBubble;
    [SerializeField] private GameObject thinkingUI;
    [SerializeField] private GameObject emoteUI;
    private ParticleSystem heartParticle;
    private TextMeshPro tmp;

    private Bancho_Cooking bancho;
    public SpeechBubble bubble;
    private bool sit;
    public bool Sit => sit;
    public EOrderType OrderType;
    public void Init(Sprite rend, Transform goal, SpeechBubble bubble, EOrderType ordertype)
    {
        Face = GetComponent<SpriteRenderer>();
        this.Face.sprite = rend;
        this.Goal = goal;

        SpriteRenderer[] speechbubble = speechBubble.GetComponentsInChildren<SpriteRenderer>();
        speechbubble[0].sprite = bubble.Bubble;
        speechbubble[1].sprite = bubble.Order;
        this.bubble = bubble;
        this.OrderType = ordertype;
    }

    private void Start()
    {
        tmp = GetComponentInChildren<TextMeshPro>();
        heartParticle = GetComponentInChildren<ParticleSystem>();
        bancho = FindObjectOfType<Bancho_Cooking>();
        MoveToChair();
        
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

    private void SitChair()
    {
        thinkingUI.SetActive(true);

    }

    public void CustomerOrder()
    {
        speechBubble.SetActive(true);
        speechBubble.transform.DOShakePosition(10, new Vector3(0, 0.02f, 0), 3,0).SetEase(Ease.Linear);

        if (OrderType.Equals(EOrderType.Tea)) return;

        bancho.Order(bubble.Order);
    }

    public void Eat()
    {
        speechBubble.SetActive(false);
        emoteUI.SetActive(true);
        heartParticle.Play();
        tmp.enabled = true;
        tmp.DOFade(0, 1f);
        //¸»Ç³¼± ²ô°í ÀÌ¸ðÆ¼ÄÜ ¶ç¿ì±â
    }
    private void OnParticleSystemStopped()
    {
        Debug.Log("ÇÏÆ®³¡");
    }
}
