using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLineController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player.Player>())
        {
            ActionController.Instance.OnAction(ActionType.Finish);
        }
    }
}
