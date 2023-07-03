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

    public void Init(Sprite rend, Transform goal, SpeechBubble bubble)
    {
        Face = GetComponent<SpriteRenderer>();
        this.Face.sprite = rend;
        this.Goal = goal;

        SpriteRenderer[] speechbubble = speechBubble.GetComponentsInChildren<SpriteRenderer>();
        speechbubble[0].sprite = bubble.Bubble;
        speechbubble[1].sprite = bubble.Order;
    }

    private void Start()
    {
        MoveToChair();
        
    }

    private void MoveToChair()
    {
        sequence = DOTween.Sequence();
        sequence.Append(transform.DOLocalMoveX(Goal.position.x, 5f).OnComplete(() =>
                                                speechBubble.SetActive(true)));
    }

}
