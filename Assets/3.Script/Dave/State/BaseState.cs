using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseState
{
    public BaseState(Harpoon harpoon, Player_Arms arms, Animator animator, Player_Underwater player, PlayerDagger dagger)
    {
        this.harpoon = harpoon;
        this.arms = arms;
        this.animator = animator;
        this.player = player;
        this.dagger = dagger;
    }

    //다같이 공유해서 쓸 것들

    protected Animator animator;
    protected Player_Underwater player;
    protected Harpoon harpoon;
    protected Player_Arms arms;
    protected PlayerDagger dagger;

    public bool HasFinished { get; protected set; } = false;

/*    private void Start()
    {
        //이거 나중에 이사보내야함
        Init();
    }*/

    protected abstract void Init();
    public abstract void Begin();
    public abstract void Tick();
    public abstract void Halt();
}
