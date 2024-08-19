using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSM
{
    // Start is called before the first frame update
    public BaseState _currentState;
    public FSM(BaseState initState)
    {
        _currentState = initState;
        ChangeState(_currentState);
    }

    public void ChangeState(BaseState nextState)
    {
        if (nextState == _currentState)
        {
            return;
        }
        if (_currentState != null)
        {
            _currentState.onStateExit();
        }
        _currentState = nextState;
        _currentState.onStateEnter();
    }

    public void UpdateState()
    {
        if (_currentState != null)
        {
            _currentState.onStateUpdate();
        }
    }
}
