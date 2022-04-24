using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Transform finalCamPos;

    [SerializeField] private float followSpeed = 5;

    private Vector3 _offset;

    private const float FinalAnimTime = 0.5f;

    private bool _isFinish;

    private void Awake()
    {
        _offset = transform.position - target.position;

        ActionController.Instance.AddMethodToAction(ActionType.Finish, FinalCamPos);
    }

    private void Update()
    {
        if (_isFinish) return;
        
        FollowTarget();
    }

    private void FinalCamPos()
    {
        _isFinish = true;
        
        transform.LeanMove(finalCamPos.position, FinalAnimTime);
        transform.LeanRotate(finalCamPos.eulerAngles, FinalAnimTime);
    }

    private void FollowTarget()
    {
        var pos = target.position;

        pos.x = 0;
        
        transform.position = Vector3.Lerp(transform.position, pos + _offset, Time.deltaTime * followSpeed);
    }
}
