using static UnityEngine.EventSystems.EventTrigger;

public abstract class State
{
    //protected Entity _entity;

    //protected State(Entity entity)
    //{
    //    _entity = entity;
    //}

    public virtual void Enter() { }
    public virtual void Execute() { }
    public virtual void Exit() { }
}