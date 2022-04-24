using System;
using UnityEngine;

namespace PrisonBars
{
    public class PrisonBarsAnimatorController : MonoBehaviour
    {
        private Animator _animator;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            
            StopAnimator();

            ActionController.Instance.AddMethodToAction(ActionType.Finish, PlayAnimator);
        }

        private void StopAnimator()
        {
            SetAnimatorTime(0);
        }
        
        private void PlayAnimator()
        {
            SetAnimatorTime(1);
        }

        private void SetAnimatorTime(float time)
        {
            _animator.speed = time;
        }
    }
}
