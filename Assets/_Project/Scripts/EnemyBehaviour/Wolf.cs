using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wolf : MonoBehaviour
{
    FSMEnemy _myFSM;

    [SerializeField]
    private bool _readyToHunt = false;

    [SerializeField]
    private bool _gotHit = false;

    public bool _playerDetected;

    public bool ReadyToHunt { get => _readyToHunt; set => _readyToHunt = value; }

    private void OnEnable()
    {
        AttackingState attacking = new(this);
        ChasingState chasing = new(this);
        CirclingState circling = new(this);
        DistractedState distracted = new(this);
        FleeingState fleeing = new(this);
        IdlingState idle = new(this);
        RoamingState roaming = new(this);

        Transition goesHunting = new(roaming, () => ReadyToHunt);
        Transition gotHit = new(fleeing, () => _gotHit);
        Transition playerDetected = new(chasing, () => _playerDetected);
        Transition pieDetected = null;
        Transition playerInAttackRange = null;

        Dictionary<State, List<Transition>> transitions = new()
        {
            { idle, new List<Transition> { goesHunting, gotHit } }, 
            { roaming, new List<Transition> { playerDetected, gotHit} },
            { chasing, new List<Transition> { pieDetected, playerInAttackRange, playerLost, gotHit} },
            { attacking, new List<Transition> { attacked, playerOutOfAttackRange, gotHit} },
            { circling, new List<Transition> { pieDetected, readyToAttack, playerOutOfAttackRange, gotHit} },
            { distracted, new List<Transition> { pieEaten} },
            { fleeing, new List<Transition> { escaped } }
        };

        _myFSM = new(this, idle, transitions);
    }


    private void Update()
    {
        _myFSM.UpdateState();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        DetectPlayer(collision);
    }

    private void DetectPlayer(Collider2D collider2D)
    {
        if (collider2D.CompareTag("Player"))
            _playerDetected = true;
        _playerDetected = false;
    }
}
