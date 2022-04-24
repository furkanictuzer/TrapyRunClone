using System;
using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;

public class SwipeController : MonoBehaviour
{
    [SerializeField] private float minXPos, maxXPos;
    
    [Range(0, 30)]
    [SerializeField] private float forwardSpeed;
    
    private float _firstValue;
    private float _currentValue;

    private float _lastSumValue;
    private float _screenWidth;

    private bool _touchable = true;

    private const float Sensitivity = 10f;
    private float _sumValue;

    private void Awake()
    {
        /*var width = //PathCreator.Instance.pathWidth;
        minXPos = -width / 2;
        maxXPos = width - width / 2 -1;*/

        DisableSwipe();
        
        FirstTouchController.Instance.AddMethodFirstTouch(EnableSwipe);
        
        ActionController.Instance.AddMethodToAction(ActionType.Fail, DisableSwipe);
        ActionController.Instance.AddMethodToAction(ActionType.Finish, DisableSwipe);
    }

    private void Start()
    {
        _screenWidth = Screen.width;
    }

    private void Update()
    {
        if (!_touchable) return;

        Move(GetTouchedPos());

        Move();

    }

    private float GetTouchedPos()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _firstValue = Input.mousePosition.x;
        }
        else if (Input.GetMouseButton(0))
        {
            _currentValue = Input.mousePosition.x;

            _sumValue = _currentValue - _firstValue;
            
            _sumValue /= _screenWidth;

            _sumValue *= Sensitivity;
            _sumValue += _lastSumValue;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            _lastSumValue = _sumValue;
        }

        return _sumValue;
    }

    private void Move(float value)
    {
        var localPosition = transform.localPosition;
        
        localPosition = Vector3.Lerp(
            localPosition, 
            new Vector3(value, localPosition.y, localPosition.z),
            10f * Time.deltaTime);
        
        localPosition.x=Mathf.Clamp(localPosition.x,minXPos,maxXPos);

        transform.localPosition = localPosition;
    }

    private void DisableSwipe()
    {
        _touchable = false;
        
        PlayerAnimatorController.Instance.SetSpeed(0);
    }

    private void EnableSwipe()
    {
        _touchable = true;
        
        PlayerAnimatorController.Instance.SetSpeed(1);
    }
    

    private void Move()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * forwardSpeed);
    }

}
