using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateBrain : MonoBehaviour
{
    public enum EState
    {
        Ready, Attack
    }

    private BaseState activeState;
    private State_Attack AttackState;
    private State_Ready ReadyState;
    private EState State;


    protected Animator animator;
    protected Player_Underwater player;
    [SerializeField] private Harpoon harpoon;
    [SerializeField] private Player_Arms arms;
    [SerializeField] private PlayerDagger dagger;

    private void Awake()
    {
        player = GetComponent<Player_Underwater>();
        animator = GetComponent<Animator>();
        Init();
    }

    private void Start()
    {
        activeState.Begin();
    }

    private void Update()
    {
        if (activeState != null)
        {
            activeState.Tick();
            if (activeState.HasFinished)
            {
                activeState = null;
            }

        }
        ChangeState();
    }

    private void ChangeState()
    {
        if(activeState == null)
        {
            switch(State)
            {
                case EState.Ready:
                    activeState = AttackState;
                    State = EState.Attack;
                    break;
                case EState.Attack:
                    activeState = ReadyState;
                    State = EState.Ready;
                    break;


            }
           activeState.Begin();

        }
    }

    private void Init()
    {
        AttackState = new State_Attack(harpoon, arms, animator, player, dagger);
        ReadyState = new State_Ready(harpoon, arms, animator, player, dagger);
        activeState = ReadyState;
        State = EState.Ready;
    }

}
