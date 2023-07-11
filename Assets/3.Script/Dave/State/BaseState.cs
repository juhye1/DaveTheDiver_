using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseState : MonoBehaviour
{
    //다같이 공유해서 쓸 것들

    protected Animator animator;
    protected Harpoon harpoon;
    protected Player_Arms arms;
    protected Player_Underwater player;

    public bool HasFinished { get; protected set; } = false;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        player = GetComponent<Player_Underwater>();
        arms = FindObjectOfType<Player_Arms>();
        harpoon = FindObjectOfType<Harpoon>();
    }
    private void Start()
    {
        Init();
    }
    protected abstract void Init();
    public abstract void Begin();
    public abstract void Tick();
    public abstract void Halt();
}
