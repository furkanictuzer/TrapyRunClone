using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private Canvas failCanvas;
    [SerializeField] private Canvas finishCanvas;

    private void Awake()
    {
        EnableCanvas(failCanvas,false);
        EnableCanvas(finishCanvas,false);
        
        ActionController.Instance.AddMethodToAction(ActionType.Finish, Finish);
        ActionController.Instance.AddMethodToAction(ActionType.Fail, Fail);
    }

    private void Finish()
    {
        EnableCanvas(finishCanvas, true, 1);
    }

    private void Fail()
    {
        EnableCanvas(failCanvas, true, 1);
    }

    private void EnableCanvas(Canvas canvas, bool enable, float delay=0)
    {
        StartCoroutine(EnableCanvasCoroutine(canvas, enable, delay));
    }

    private static IEnumerator EnableCanvasCoroutine(Canvas canvas, bool enable, float delay)
    {
        yield return new WaitForSeconds(delay);
        
        canvas.enabled = enable;
        
    }
}
