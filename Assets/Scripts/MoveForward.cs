using System;
using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    
    [Space]
    [Range(0,30)]
    [SerializeField] private float forwardSpeed;

    private bool _canMove;

    private void Awake()
    {
        DisableMove();
        
        FirstTouchController.Instance.AddMethodFirstTouch(EnableMove);
    }

    private void Update()
    {
        if (!_canMove) return;
        
        Move();
    }

    private void Move()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * forwardSpeed);
    }
    
    public void DisableMove()
    {
        _canMove = false;
    }

    public void EnableMove()
    {
        _canMove = true;
    }
}
