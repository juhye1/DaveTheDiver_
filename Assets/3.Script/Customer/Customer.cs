using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Customer : MonoBehaviour
{
    private SpriteRenderer Face;
    private Transform Goal;
    private Sequence sequence;
    [SerializeField] private GameObject speechBubble;
    [SerializeField] private GameObject thinkingUI;
    private Bancho_Cooking bancho;
    private SpeechBubble bubble;
    private bool sit;
    public bool Sit => sit;

    public void Init(Sprite rend, Transform goal, SpeechBubble bubble)
    {
        Face = GetComponent<SpriteRenderer>();
        this.Face.sprite = rend;
        this.Goal = goal;

        SpriteRenderer[] speechbubble = speechBubble.GetComponentsInChildren<SpriteRenderer>();
        speechbubble[0].sprite = bubble.Bubble;
        speechbubble[1].sprite = bubble.Order;
        this.bubble = bubble;
    }

    private void Start()
    {
        bancho = FindObjectOfType<Bancho_Cooking>();
        MoveToChair();
        
    }

    private void MoveToChair()
    {
        float distance = transform.position.x - Goal.position.x;
        distance = Mathf.Abs(distance);
        float duration = distance / 1.4f;
        Debug.Log(duration);
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
        bancho.Order(bubble.Order);
    }
}
