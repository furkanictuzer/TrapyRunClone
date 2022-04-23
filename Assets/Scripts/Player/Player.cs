using System;
using UnityEngine;

namespace Player
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private RagDollController ragDollController;
        [SerializeField] private PlayerAnimatorController playerAnimatorController;

        private void Awake()
        {
            ActionController.Instance.AddMethodToAction(ActionType.Fail, Fail);
        }

        private void Fail()
        {
            playerAnimatorController.EnableAnimator(false);
            ragDollController.EnableRagDoll(true);
        }
    }
}
