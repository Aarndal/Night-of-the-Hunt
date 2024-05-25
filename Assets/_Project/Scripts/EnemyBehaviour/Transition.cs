using System;
public class Transition
{
    private Condition _condition;
    private State _targetState;
    private Action _actions;
    public State TargetState => _targetState;
    public Action Actions => _actions;
    public bool IsTriggered => _condition.Test();

    public Transition(State targetState, Condition condition)
    {
        _targetState = targetState;
        _condition = condition;
    }
}
