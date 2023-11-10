using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    
    private int _isRunning;
    private int _isShooting;
    private int _isHurt;
    private int _isThrowing;
    
    private void Awake()
    {
    _isRunning = Animator.StringToHash("isRunning");
    _isShooting = Animator.StringToHash("isShooting");
    _isHurt = Animator.StringToHash("isHurt");
    _isThrowing = Animator.StringToHash("isThrowing");
    }
    
    public void PlayerIsRunning(bool value)
    {
        _animator.SetBool(_isRunning , value);
    }

    public void PlayerIsThrowing(bool value)
    {
        _animator.SetBool(_isThrowing , value);
    }

    public void PlayerIsShoothing()
    {
        _animator.SetTrigger(_isShooting);
    }
    
    public void PlayerIsHurt()
    {
        _animator.SetTrigger(_isHurt);
    }

    private void Start()
    {
        EventManager.Instance.OnMagnitudeChanged += PlayAnimation;
    }
    
    private void PlayAnimation(float value)
    {
        PlayerIsRunning(value > 0);
    }

    private void Update()
    {
        PlayShootingAnimation();
    }

    private void PlayShootingAnimation()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlayerIsShoothing();
        }   
    }

}
