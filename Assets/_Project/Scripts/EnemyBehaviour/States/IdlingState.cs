using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdlingState : State
{
    private float _timer;

    public override void Enter()
    {
        _timer = 0.0f;
    }

    public override void Execute()
    {
        _timer += Time.deltaTime;
    }

    public override void Exit()
    {

    }
}
