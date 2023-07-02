using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Customer : MonoBehaviour
{
    public SpriteRenderer Face;
    public Transform Goal;

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
        transform.DOLocalMoveX(Goal.position.x, 5f);
    }


}
