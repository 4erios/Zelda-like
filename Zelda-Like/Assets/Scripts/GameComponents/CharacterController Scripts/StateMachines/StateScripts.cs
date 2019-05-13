
//StateMachineBehavior template for GameEvent
//Copyright (c) Arthur Herbreteau

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateScripts : StateMachineBehaviour
{
    [SerializeField] private GameEvent[] startEvent /*= default*/;
    [SerializeField] private GameEvent[] exitEvent /*= default*/;
    [SerializeField] private GameEvent[] updateEvent /*= default*/;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (startEvent.Length == 0)
            return;
        foreach (GameEvent item in startEvent)
            item.Raise();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (updateEvent.Length == 0)
            return;
        foreach (GameEvent item in updateEvent)
            item.Raise();
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (exitEvent.Length == 0)
            return;
        foreach (GameEvent item in exitEvent)
            item.Raise();
    }
}
