using Runtime.Managers;
using UnityEngine;

namespace Runtime.Player
{
    public class PlayerAnimationController : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
    
        private int _isRunning;
        private int _isShooting;
        private int _isHurt;
        private int _isThrowing;
        private int _isRunShooting;
        private bool _playerIsRunningCheck;
        private void Awake()
        {
            _isRunning = Animator.StringToHash("isRunning");
            _isShooting = Animator.StringToHash("isShooting");
            _isRunShooting = Animator.StringToHash("isRunShooting");
            _isHurt = Animator.StringToHash("isHurt");
            _isThrowing = Animator.StringToHash("isThrowing");
        }

        #region AnimationSetRegion
    
        public bool PlayerIsRunning(bool value)
        {
            _animator.SetBool(_isRunning , value);

            return value;
        }
    
        public void PlayerIsRunShooting(bool value)
        {
            _animator.SetBool(_isRunShooting , value);
        }

        public void PlayerIsThrowing(bool value)
        {
            _animator.SetBool(_isThrowing , value);
        }

        public void PlayerIsShooting(bool value)
        {
            _animator.SetBool(_isShooting , value);
        }
    
        public void PlayerIsHurt()
        {
            _animator.SetTrigger(_isHurt);
        }

        #endregion
        private void Start()
        {
            EventManager.Instance.OnMagnitudeChanged += PlayRunningAnimation;
            EventManager.Instance.OnShootingChanged += PlayShootingAnimation;
            EventManager.Instance.OnThrowingChanged += PlayThrowingAnimation;
        }

        private void PlayThrowingAnimation(bool value)
        {
            PlayerIsThrowing(value);
            if (!value)
            {
                PlayerIsThrowing(false);
            }
        }

        private void PlayRunningAnimation(float value)
        {
            if (PlayerIsRunning(value > 0.1f))
            {
                _playerIsRunningCheck = true;
            }
            else
            {
                _playerIsRunningCheck = false;
            }
        }
    
        private void PlayShootingAnimation(bool value)
        {
            if (_playerIsRunningCheck)
            {
                PlayerIsRunShooting(value);
                PlayerIsShooting(false);
            }
            else if (!_playerIsRunningCheck)
            {
                PlayerIsRunShooting(false);
                PlayerIsShooting(value);
            }
        }

    }
}
