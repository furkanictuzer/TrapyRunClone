using UnityEngine;

namespace Player
{
    public class PlayerAnimatorController : MonoSingleton<PlayerAnimatorController>
    {
        private Animator _animator;
    
        private static readonly int Speed = Animator.StringToHash("Speed");
        private static readonly int Finish = Animator.StringToHash("Finish");

        private void Awake()
        {
            _animator = GetComponent<Animator>();

            ActionController.Instance.AddMethodToAction(ActionType.Finish, FinishDance);
        }
        
        public void EnableAnimator(bool enable)
        {
            _animator.enabled = enable;
        }

        private void FinishDance()
        {
            _animator.SetTrigger(Finish);
        }

        public void SetSpeed(float speed)
        {
            if (_animator == null) return;
        
            _animator.SetFloat(Speed, speed);
        }
    }
}
