using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSMEnemy
{
    private State _currentState;
    private Dictionary<State, List<Transition>> _transitions;
    private Wolf _entity;
    
    public FSMEnemy(Wolf entity, State initialState, Dictionary<State, List<Transition>> transitions)
    {
        _entity = entity;
        _currentState = initialState;
        _transitions = transitions;
    }

    public void UpdateState()
    {
        State targetState = GetTargetState();

        if (targetState != null)
            SwitchState(targetState);

        _currentState.Execute();
    }

    private State GetTargetState()
    {
        List<Transition> currentTransitions = _transitions[_currentState]; // Get the list of transitions for the current state.

        foreach (Transition transition in currentTransitions)
        {
            if (transition.Condition())
                return transition.TargetState;
        }

        return null;
    }

    private void SwitchState(State targetState)
    {
        if (_currentState == targetState) return;

        _currentState.Exit();
        targetState.Enter();

        _currentState = targetState;
    }
}
