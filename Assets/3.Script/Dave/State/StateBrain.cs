using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateBrain : MonoBehaviour
{
    private BaseState activeState;
    private BaseState readyState;
    private BaseState attackState;

    private void Awake()
    {
        readyState = GetComponent<State_Ready>();
        attackState = GetComponent<State_Attack>();

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
        activeState = attackState;
        activeState.Begin();
    }


}
