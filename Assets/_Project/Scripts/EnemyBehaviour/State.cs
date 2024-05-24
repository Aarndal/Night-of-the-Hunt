using static UnityEngine.EventSystems.EventTrigger;

public abstract class State
{
    protected Wolf _wolf;

    public State(Wolf wolf)
    {
        _wolf = wolf;
    }
    
    public abstract void Enter();
    public abstract void Execute();
    public abstract void Exit();
}