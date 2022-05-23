using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : Entity
{
    private IGun[] _guns;
    private IDamagable _damagable;

    protected override void Awake()
    {
        base.Awake();
        _guns = GetComponentsInChildren<IGun>();
        _damagable = GetComponent<IDamagable>();
    }

    public void TakeDamage(int damage)
    {
        _damagable.TakeDamage(damage);
    }

    public void AddLife(int life)
    {
        _damagable.AddLife(life);
    }

    public void Fire()
    {
        if (_guns != null)
            foreach (IGun gun in _guns)
                gun.Fire();
    }
    
}
