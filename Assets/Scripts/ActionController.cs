using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ActionType
{
    Finish,
    Fail
}
public class ActionController : MonoSingleton<ActionController>
{
    private Action _failAction;
    private Action _finishAction;

    private bool _isCalled;

    public void OnAction(ActionType actionType)
    {
        if (_isCalled) return;
        
        switch (actionType)
        {
            case ActionType.Fail:
                _failAction?.Invoke();
                break;
            case ActionType.Finish:
                _finishAction?.Invoke();
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(actionType), actionType, null);
        }
        
        _isCalled = true;
    }

    public void AddMethodToAction(ActionType actionType, params Action[] methods)
    {
        switch (actionType)
        {
            case ActionType.Finish:
                foreach (var method in methods)
                    _finishAction += method;
                break;
            case ActionType.Fail:
                foreach (var method in methods)
                    _failAction += method;
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(actionType), actionType, null);
        }
    }
}
