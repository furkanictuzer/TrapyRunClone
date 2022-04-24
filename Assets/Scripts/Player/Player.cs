using System;
using UnityEngine;

namespace Player
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private RagDollController ragDollController;
        
        [SerializeField] private PlayerAnimatorController playerAnimatorController;
        
        [Space]
        [SerializeField] private Transform playerFinalPos;

        private void Awake()
        {
            ActionController.Instance.AddMethodToAction(ActionType.Fail, Fail);
            ActionController.Instance.AddMethodToAction(ActionType.Finish, Finish);
        }

        private void Fail()
        {
            playerAnimatorController.EnableAnimator(false);
            ragDollController.EnableRagDoll(true);
        }

        private void Finish()
        {
            var pos = playerFinalPos.position;
            var targetRotation = new Vector3(0, 180, 0);
            
            pos.y = transform.position.y;

            transform.LeanRotate(targetRotation, 1);
            transform.LeanMove(pos, 1);
        }
    }
}
