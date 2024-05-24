using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wolf : MonoBehaviour
{
    FSMEnemy _myFSM;

    [SerializeField]
    private bool _readyToHunt = false;




    private void Awake()
    {
        AttackingState attacking = new();
        ChasingState chasing = new();
        CirclingState circling = new();
        DistractedState distracted = new();
        FleeingState fleeing = new();
        IdlingState idle = new();
        RoamingState roaming = new();

        Transition goesHunting = new(roaming, () => _readyToHunt);
        Transition gotHit = new(fleeing, () => true);

        Dictionary<State, List<Transition>> transitions = new()
        {
            { idle, new List<Transition> { goesHunting } }
        };

        _myFSM = new(this, idle, transitions);


    }


}
