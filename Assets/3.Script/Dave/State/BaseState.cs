using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseState : MonoBehaviour
{
    //다같이 공유해서 쓸 것들

    protected Animator animator;
    protected Player_Underwater player;
    protected Harpoon harpoon;
    protected Player_Arms arms;

    public bool HasFinished { get; protected set; } = false;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        player = GetComponent<Player_Underwater>();
    }
    private void Start()
    {
        //이거 나중에 이사보내야함
        Init();
    }

    public void dd(Harpoon harpoon, Player_Arms arms)
    {
        this.harpoon = harpoon;
        this.arms = arms;
    }

    protected abstract void Init();
    public abstract void Begin();
    public abstract void Tick();
    public abstract void Halt();
}
