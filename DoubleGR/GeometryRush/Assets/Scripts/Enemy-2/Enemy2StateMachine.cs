using UnityEngine;

public class Enemy2StateMachine : MonoBehaviour
{
    [SerializeField] private State _firstState;

    private Player _target;
    private State _currentState;

    public State CurrentState => _currentState;

    private void OnEnable()
    {
        _target = GetComponentInParent<Spawner>().Player;
        Reset(_firstState);
    }

    private void OnDisable()
    {
        if (_currentState != null)
            _currentState.Exit();

        Reset(_firstState);
    }

    private void Update()
    {
        if (_currentState == null)
            return;

        var nextState = _currentState.GetNextState();

        if (nextState != null)
            Transit(nextState);
    }

    public void SetTarget(Player target)
    {
        _target = target;
    }

    private void Reset(State startState)
    {
        _currentState = startState;

        if (_currentState != null)
            _currentState.Enter(_target);
    }

    private void Transit(State nextState)
    {
        if (_currentState != null)
            _currentState.Exit();

        _currentState = nextState;

        if (_currentState != null)
            _currentState.Enter(_target);
    }
}

