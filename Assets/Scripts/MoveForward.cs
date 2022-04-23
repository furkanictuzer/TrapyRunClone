using System;
using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;

    [SerializeField] private float acceleration = 0.5f;
    
    private float _forwardSpeed;

    private bool _isFail;

    private void Update()
    {
        SetSpeed();
        
        if (_isFail) return;
        
        Move();
    }

    private void SetSpeed()
    {
        _forwardSpeed = (playerTransform.position.z - transform.position.z) * acceleration;
    }

    private void Move()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * _forwardSpeed);
    }
    
    public void DisableMove()
        {
            _isFail = true;
        }
}
