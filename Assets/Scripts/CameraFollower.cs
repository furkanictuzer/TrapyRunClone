using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    [SerializeField] private Transform target;

    [SerializeField] private float followSpeed = 5;

    private Vector3 _offset;

    private void Awake()
    {
        _offset = transform.position - target.position;
    }

    private void Update()
    {
        FollowTarget();
    }

    private void FollowTarget()
    {
        var pos = target.position;

        pos.x = 0;
        
        transform.position = Vector3.Lerp(transform.position, pos + _offset, Time.deltaTime * followSpeed);
    }
}
