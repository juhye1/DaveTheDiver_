using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateBrain : MonoBehaviour
{
    private List<BaseState> baseStates;
    private BaseState activeState;
    private BaseState readyState;
    private BaseState attackState;

    [SerializeField] private Harpoon harpoon;
    [SerializeField] private Player_Arms arms;

    private void Awake()
    {
        baseStates = new List<BaseState>();
        readyState = GetComponent<State_Ready>();
        attackState = GetComponent<State_Attack>();
        baseStates.Add(readyState);
        baseStates.Add(attackState);
        foreach(BaseState state in baseStates)
        {
            state.dd(harpoon, arms);
        }

        activeState = readyState;
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
            activeState = attackState;
           activeState.Begin();

        }
    }


}
