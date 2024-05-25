using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Transition
{
    private Func<bool> _condition;
    private State _targetState;

    public Func<bool> Condition => _condition;
    public State TargetState => _targetState;

    public Transition(State targetState, Func<bool> condition)
    {
        _targetState = targetState;
        _condition = condition;
    }
}
