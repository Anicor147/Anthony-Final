using Runtime.Managers;
using Runtime.Menu;
using UnityEngine;

namespace Runtime.Player.PlayerScripts
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
            _isHurt = Animator.StringToHash("isHurt");

            if (!CharacterSelectScripts._isPlayer1) return;
            _isRunShooting = Animator.StringToHash("isRunShooting");
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
            if (CharacterSelectScripts._isPlayer2) return;
            
            _animator.SetBool(_isRunShooting , value);
        }

        public void PlayerIsThrowing(bool value)
        {
            if (CharacterSelectScripts._isPlayer2) return;
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
            //Subscribe to Event - Source PlayerMovement 
            EventManager.Instance.OnMagnitudeChanged += PlayRunningAnimation;
            //Subscribe to Event - Source PlayerAttack 
            EventManager.Instance.OnShootingChanged += PlayShootingAnimation;
            EventManager.Instance.OnThrowingChanged += PlayThrowingAnimation;
            EventManager.Instance.OnPlayerHurt += PlayerIsHurtAnimation;
        }

        private void PlayerIsHurtAnimation(bool isHurt)
        {
            if (isHurt)
            {
                PlayerIsHurt();
            }
        }
        //Play ThrowingAnimation
        private void PlayThrowingAnimation(bool value)
        {
            PlayerIsThrowing(value);
            if (!value)
            {
                PlayerIsThrowing(false);
            }
        }

        //Play Running Animation
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
        
        //PlayShootingAnimation
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
