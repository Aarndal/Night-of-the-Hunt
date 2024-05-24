using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSMEnemy : MonoBehaviour
{
    private State _currentState;
    private Dictionary<State, List<Transition>> _transitions;

    public FSMEnemy(State startState, Dictionary<State, List<Transition>> transitions)
    {
        _currentState = startState;
        _transitions = transitions;
    }

    public void UpdateState()
    {
        State nextState = GetNextState();

        if (nextState != null)
            SwitchState(nextState);

        _currentState.Execute();
    }

    private State GetNextState()
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
