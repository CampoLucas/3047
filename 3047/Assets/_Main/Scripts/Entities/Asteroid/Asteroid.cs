using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : Entity
{
    private Damageable _damagable;
    protected override void Awake()
    {
        base.Awake();
        _damagable = GetComponent<Damageable>();
        if (_damagable)
            _damagable.OnDie.AddListener(OnDieListener);
    }
    public virtual void TakeDamage(int damage)
    {
        if (_damagable)
            _damagable.TakeDamage(damage);
    }
    public virtual void OnDieListener() => Destroy(gameObject);
}
