using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BaseStateMachine<T> : BaseState
{
    public BaseStateMachine(Harpoon harpoon, Player_Arms arms, Animator animator, Player_Underwater player, PlayerDagger dagger) : 
        base(harpoon, arms, animator, player, dagger)
    {
/*        this.harpoon = harpoon;
        this.arms = arms;
        this.animator = animator;
        this.player = player;*/
    }

    class StateConfig
    {
        public Action OnEnter;
        public Action OnTick;
        public Action OnExit;

        public Func<T> CheckTransition;
    }

    protected T State { get; private set; }
    [SerializeField] protected T InitialState;
    private Dictionary<T, StateConfig> StateMachine = new Dictionary<T, StateConfig>();
    protected void AddState(T state, Action onEnterFn = null,
                                     Action onTickFn = null,
                                     Action onExitFn = null,
                                     Func<T> checkTransitionFn = null)
    {
        StateMachine[state] = new StateConfig()
        {
            OnEnter = onEnterFn != null ? onEnterFn : OnEnter,
            OnTick = onTickFn != null ? onTickFn : OnTick,
            OnExit = onExitFn != null ? onExitFn : OnExit,
            CheckTransition = checkTransitionFn != null ? checkTransitionFn : CheckTransition
        };
    }
    protected override void Init()
    {
        
    }

    public override void Tick()
    {
        StateMachine[State].OnTick();

        T nextState = StateMachine[State].CheckTransition();
        if (EqualityComparer<T>.Default.Equals(State, nextState))
            return;

        StateMachine[State].OnExit();
        State = nextState;
        StateMachine[State].OnEnter();

    }


    protected virtual void OnEnter()
    {

    }

    protected virtual void OnTick()
    {

    }

    protected virtual void OnExit()
    {

    }

    protected virtual T CheckTransition()
    {
        return State;
    }

    public sealed override void Begin()
    {
        Init();
        State = InitialState;
        HasFinished = false;
        StateMachine[State].OnEnter();
    }

    public sealed override void Halt()
    {
        StateMachine[State].OnExit();
    }

}
