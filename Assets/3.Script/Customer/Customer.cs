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

    /*    public Customer(Sprite rend, Transform goal)
        {
            this.Face.sprite = rend;
            this.Goal = goal;
            //this.Animator = animator;
        }
    */
    public void Init(Sprite rend, Transform goal)
    {
        Face = GetComponent<SpriteRenderer>();
        this.Face.sprite = rend;
        this.Goal = goal;
    }

    private void Start()
    {
        sequence = DOTween.Sequence();
        sequence.Append(transform.DOLocalMoveX(Goal.position.x, 5f).OnComplete(() => 
                                                speechBubble.SetActive(true)));
        
    }


}
