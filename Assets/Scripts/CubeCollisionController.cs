using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class CubeCollisionController : MonoBehaviour
{
    private Rigidbody _body;

    private Collider _collider;

    private Renderer _renderer;

    private const float AnimTime = 2f;

    private void Awake()
    {
        _collider = GetComponent<Collider>();
        
        _body = GetComponent<Rigidbody>();
        
        _renderer = GetComponent<Renderer>();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Player.Player>())
        {
            Debug.Log("fall");
            Fall();
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.GetComponent<Player.Player>())
        {
            Fall();
        }
    }

    private void Fall()
    {
        _body.isKinematic = false;
        
        _collider.isTrigger = true;
        
        FallAnim();
    }

    private void FallAnim()
    {
        //transform.DOMoveY(transform.position.y - 15, AnimTime);
        _renderer.material.DOColor(Color.red, AnimTime).OnComplete(() => Destroy(gameObject));
    }
}
