using System;
using UnityEngine;

public class WolfStateMachine : MonoBehaviour
{
    private FSM _myFSM;

    [SerializeField]
    private bool _readyToHunt = false;

    public Action<Collider2D> _triggeredChanged;

    private void Awake()
    {
        CreateStateMachine();
    }

    private void OnEnable()
    {
        _myFSM?.ResetState();
    }

    private void Update()
    {
        _myFSM.UpdateState()();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _triggeredChanged?.Invoke(collision);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _triggeredChanged?.Invoke(collision);
    }
    private void CreateStateMachine()
    {
        State IdleState = new State(
            () => Debug.Log("Entered Idle State"),
            Howling,
            () => Debug.Log("Exiting Idle State"));

        State RunningState = new State(
            () => Debug.Log("Entered Running State"),
            () => Debug.Log("Is Running"),
            () => Debug.Log("Exiting Running State"));

        IdleState.Transitions = new Transition[] { new(RunningState, new(() => _readyToHunt)) };

        _myFSM = new FSM(IdleState);
    }
    private void Howling()
    {
        transform.Rotate(0, 1, 0);
    }
}
