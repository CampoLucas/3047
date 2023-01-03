using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimaion : MonoBehaviour, IAnimation
{
    private Animator _anim;
    private int _vertical;
    private int _horizontal;
    private int _dodge;
    private int _damage;
    

    private void Awake()
    {
        _anim = GetComponent<Animator>();
        _vertical = Animator.StringToHash("Vertical");
        _horizontal = Animator.StringToHash("Horizontal");
        _dodge = Animator.StringToHash("Dodge");
        _damage = Animator.StringToHash("Damage");
    }

    public void UpdateMovementAnim(Vector2 moveDir)
    {
        var h = moveDir.x;
        var v = moveDir.y;
        
        _anim.SetFloat(_vertical, v, 0.1f, Time.deltaTime);
        _anim.SetFloat(_horizontal, h, 0.1f, Time.deltaTime);
    }

    public void ToggleDamage() => _anim.SetTrigger(_damage);

    public void ToggleDodge() => _anim.SetTrigger(_dodge);
}
