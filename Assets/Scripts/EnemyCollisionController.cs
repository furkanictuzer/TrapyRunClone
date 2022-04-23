using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollisionController : MonoBehaviour
{
    [SerializeField] private RagDollController ragDollController;
    [Space]
    [SerializeField] private EnemyAnimatorController animatorController;

    private MoveForward _moveForward;

    private const float EnableRagDollDelay = .5f;

    private void Awake()
    {
        _moveForward = GetComponent<MoveForward>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player.Player>())
        {
            Catch(other.transform.position);
        }
    }

    /*private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Player.Player>())
        {
            Catch(collision.transform.position);
        }
    }*/

    private void Catch(Vector3 caughtPos)
    {
        StartCoroutine(CatchCoroutine(caughtPos,EnableRagDollDelay));
    }

    private IEnumerator CatchCoroutine(Vector3 caughtPos,float time)
    {
        ActionController.Instance.OnAction(ActionType.Fail);
        
        _moveForward.DisableMove();

        animatorController.Catch();

        transform.LeanMove(caughtPos+Vector3.up, time);

        yield return new WaitForSeconds(time);
        
        animatorController.EnableAnimator(false);

        ragDollController.EnableRagDoll(true);

    }
}
