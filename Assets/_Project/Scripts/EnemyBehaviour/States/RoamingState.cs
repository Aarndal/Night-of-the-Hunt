using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoamingState : State
{
    public RoamingState(Wolf wolf) : base(wolf)
    {
    }

    public override void Enter()
    {
        Debug.Log("Roaming");
    }

    public override void Execute()
    {
        throw new System.NotImplementedException();
    }

    public override void Exit()
    {
        throw new System.NotImplementedException();
    }
}
