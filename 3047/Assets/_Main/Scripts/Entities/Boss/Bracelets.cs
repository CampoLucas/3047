using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bracelets : Ship
{
    private Boss _boss;

    private void Awake()
    {
        _boss = GetComponentInParent<Boss>();
    }

    public override void OnDieListener()
    {
        _boss.TakeDamage(_boss.Data.Life / 4);
        _boss.ChangeRotationDirection();
        
        
        base.OnDieListener();
    }
}
