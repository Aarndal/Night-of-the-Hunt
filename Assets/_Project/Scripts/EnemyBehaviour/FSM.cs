using System;

public class FSM
{
    private State _initialState;
    private State _currentState;

    public void ResetState()
    {
        if (_initialState is not null)
            _currentState = _initialState;
    }

    public FSM(State initialState)
    {
        _initialState = initialState;
        _currentState = initialState;
    }

    public Action UpdateState()
    {
        Transition triggeredTransition = null;

        if (_currentState.Transitions is not null)
            foreach (Transition transition in _currentState.Transitions)
            {
                if (transition.IsTriggered)
                {
                    triggeredTransition = transition;
                    break;
                }
            }

        if (triggeredTransition is not null)
        {
            State targetState = triggeredTransition.TargetState;
            Action actions = _currentState.ExitActions;
            actions += triggeredTransition.Actions;
            actions += targetState.EnterActions;

            _currentState = targetState;

            return actions;
        }

        return _currentState.ExecuteActions;
    }
}
