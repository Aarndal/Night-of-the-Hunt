using static UnityEngine.EventSystems.EventTrigger;

public abstract class State
{
    public abstract void Enter();
    public abstract void Execute();
    public abstract void Exit();
}