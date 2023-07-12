using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateBrain : MonoBehaviour
{
    private BaseStateMachine<State_Attack.EState> fattackState;

    private List<BaseState> baseStates;

    private BaseState activeState;
    private State_Attack AttackState;
    private State_Ready ReadyState;


    protected Animator animator;
    protected Player_Underwater player;
    [SerializeField] private Harpoon harpoon;
    [SerializeField] private Player_Arms arms;

    private void Awake()
    {
        player = GetComponent<Player_Underwater>();
        animator = GetComponent<Animator>();
        Init();

        //attackState = new BaseStateMachine<State_Attack.EState>(harpoon, arms, animator, player);
        //activeState = rdy;
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
        if(activeState==null)
        {
           activeState = AttackState;
           activeState.Begin();

        }
    }

    private void Init()
    {
        AttackState = new State_Attack(harpoon, arms, animator, player);
        ReadyState = new State_Ready(harpoon, arms, animator, player);

        baseStates = new List<BaseState> { AttackState, ReadyState };
        activeState = ReadyState;
    }

}
