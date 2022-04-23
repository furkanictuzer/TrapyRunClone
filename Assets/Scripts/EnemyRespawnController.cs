using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRespawnController : MonoBehaviour
{
    [SerializeField] private Transform camTransform;
    [SerializeField] private Transform playerTransform;

    private Rigidbody _body;

    private Collider _collider;
    
    private Vector3 _prevPos;
    private Vector3 _initPos;

    private float _spawnZOffset;
    private const float ControlYOffset = .01f;
    private const float PassPlayerOffset = 2f;
    private const float RespawnDelayTime = 2;

    private bool _isRespawned;
    private bool _isFalling;
    private bool _controlRespawn = true;

    private void Awake()
    {
        _spawnZOffset = transform.position.z - camTransform.position.z;
        
        _collider = GetComponent<Collider>();
        
        _body = GetComponent<Rigidbody>();
        
        _initPos = transform.position;
        
        _prevPos = _initPos;

        ActionController.Instance.AddMethodToAction(ActionType.Fail, DisableRespawn);
        ActionController.Instance.AddMethodToAction(ActionType.Finish, DisableRespawn);
    }

    private void FixedUpdate()
    {
        if (!_controlRespawn) return;
        
        var fall = _prevPos.y > transform.position.y + ControlYOffset;
        var isPassPlayer = transform.position.z > playerTransform.position.z + PassPlayerOffset;
        
        if ((fall && !_isFalling))
        {
            _isFalling = true;
            
            Respawn();

            //StartCoroutine(TriggerColliderCoroutine(RespawnDelayTime));
        }
        else if (isPassPlayer)
        {
            _isFalling = true;
            
            Respawn();
        }
        
        _prevPos = transform.position;
    }

    private void DisableRespawn()
    {
        _controlRespawn = false;
    }

    private void Respawn()
    {
        StartCoroutine(RespawnCoroutine(RespawnDelayTime));
    }

    private IEnumerator RespawnCoroutine(float time)
    {
        yield return new WaitForSeconds(time);

        var newPos = _initPos;

        newPos.z = camTransform.position.z + _spawnZOffset;
        //newPos.y += 0.1f;

        transform.position = newPos;

        _body.velocity = Vector3.zero;

        _isFalling = false;
    }

    private IEnumerator TriggerColliderCoroutine(float time)
    {
        _collider.isTrigger = true;
        
        yield return new WaitForSeconds(time);

        _collider.isTrigger = false;
    }
}
