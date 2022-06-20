using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHandler : MonoBehaviour, IAnimation
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

    public void UpdateAnimValues(float horizontal, float vertical, bool isBoosting)
    {
        float h = horizontal;
        float v = vertical;

        if (horizontal > .55f && isBoosting)
            h = 2;
        else if (horizontal < -.55f && isBoosting)
            h = -2;

        _anim.SetFloat(_vertical, v, 0.1f, Time.deltaTime);
        _anim.SetFloat(_horizontal, h, 0.1f, Time.deltaTime);
    }

    public void ToggleDamage() => _anim.SetTrigger(_damage);

    public void ToggleDodge() => _anim.SetTrigger(_dodge);
}
