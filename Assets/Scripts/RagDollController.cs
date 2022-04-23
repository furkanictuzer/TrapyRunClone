using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagDollController : MonoBehaviour
{
    private Rigidbody[] _ragDollBodies;
    private Collider[] _ragDollColliders;

    private Collider _parentCollider;
    private Rigidbody _parentBody;
    
    private void Awake()
    {
        _ragDollBodies = GetComponentsInChildren<Rigidbody>();
        _ragDollColliders = GetComponentsInChildren<Collider>();

        _parentBody = transform.parent.GetComponent<Rigidbody>();
        _parentCollider = transform.parent.GetComponent<Collider>();
        
        EnableRagDoll(false);
    }

    public void EnableRagDoll(bool enable)
    {
        foreach (var body in _ragDollBodies)
        {
            body.isKinematic = !enable;
        }

        foreach (var collider1 in _ragDollColliders)
        {
            collider1.enabled = enable;
        }

        if (transform.parent.CompareTag("Player")) return;
        
        _parentBody.useGravity = !enable;
        _parentCollider.enabled = !enable;

    }
}
