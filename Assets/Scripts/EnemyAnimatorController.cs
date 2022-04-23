using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimatorController : MonoBehaviour
{
    private Animator _animator;
    
    private static readonly int Catch1 = Animator.StringToHash("Catch");

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void EnableAnimator(bool enable)
    {
        _animator.enabled = enable;
    }

    public void Catch()
    {
        _animator.SetTrigger(Catch1);
    }
}
