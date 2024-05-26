using System;
public class State
{
    public Action EnterActions;
    public Action ExecuteActions;
    public Action ExitActions;
    public Transition[] Transitions;

    public State(Action enter, Action execute, Action exit)
    {
        EnterActions = enter;
        ExecuteActions = execute;
        ExitActions = exit;
    }
}