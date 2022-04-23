using UnityEngine;

namespace Player
{
    public class PlayerAnimatorController : MonoSingleton<PlayerAnimatorController>
    {
        private Animator _animator;
    
        private static readonly int Speed = Animator.StringToHash("Speed");

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }
        
        public void EnableAnimator(bool enable)
        {
            _animator.enabled = enable;
        }

        public void SetSpeed(float speed)
        {
            if (_animator == null) return;
        
            _animator.SetFloat(Speed, speed);
        }
    }
}
