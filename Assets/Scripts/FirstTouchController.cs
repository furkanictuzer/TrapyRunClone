using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstTouchController : MonoSingleton<FirstTouchController>
{
    [SerializeField] private GameObject tutorial;
    
    private Action _firstTouchAction;
    
    private bool _firstTouch =false;

    private void Awake()
    {
        AddMethodFirstTouch(DisableTutorial);
    }

    private void Update()
    {
        if (!Input.GetMouseButtonUp(0) || _firstTouch) return;
        _firstTouch = true;
            
        OnFirstTouch();
    }

    private void DisableTutorial()
    {
        tutorial.SetActive(false);
    }

    private void OnFirstTouch()
    {
        _firstTouchAction?.Invoke();
    }

    public void AddMethodFirstTouch(params Action[] methods)
    {
        foreach (var method in methods)
            _firstTouchAction += method;
    }
}
