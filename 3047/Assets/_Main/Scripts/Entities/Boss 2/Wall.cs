using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : Ship
{
    private Animator _anim;

    protected override void Awake()
    {
        _anim = GetComponent<Animator>();
    }
    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
        _anim.SetTrigger("Damage");
    }

    public override void OnDieListener()
    {
        base.OnDieListener();
    }
}
