using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdlingState : State
{
    private float _timer;
    private float _maxTime = 10.0f; // TO-DO ScriptableObject

    public IdlingState(Wolf wolf) : base(wolf)
    {
    }

    public override void Enter()
    {
        _timer = 0.0f;
    }

    public override void Execute()
    {
        _timer += Time.deltaTime;

        Debug.LogFormat($"Time: {_timer}");

        if(_timer >= _maxTime)
            this._wolf.ReadyToHunt = true;
    }

    public override void Exit()
    {
        this._wolf.ReadyToHunt = false;
    }
}
