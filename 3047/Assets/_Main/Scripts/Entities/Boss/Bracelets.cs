using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bracelets : Ship
{
    private Boss _boss;
    private Animator _anim;

    protected override void Awake()
    {
        _boss = GetComponentInParent<Boss>();
        _anim = GetComponent<Animator>();
    }

    public override void OnDieListener()
    {
        _boss.TakeDamage(_boss.Data.Life / 4);
        _boss.IncrementRotationSpeed(20);
        _boss.ChangeRotationDirection();
        
        
        base.OnDieListener();
    }

    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
        _anim.SetTrigger("Damage");
    }
}
