using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : Entity
{
    public IDamageable Damageable { get; private set; }
    protected IGun[] _guns;
    protected override void Awake()
    {
        base.Awake();
        _guns = GetComponentsInChildren<IGun>();
    }

    protected override void Start()
    {
        base.Start();
        Damageable = GetComponent<IDamageable>();
        if (Damageable == null) return;
        Damageable.OnDie += DieHandler;
    }

    public virtual void TakeDamage(int damage)
    {
        Damageable?.TakeDamage(damage);
        
        //AudioManager.instance.Play("Hit");
    }

    public virtual void AddLife(int life)
    {
        Damageable?.AddLife(life);
    }

    public virtual void Fire()
    {
        if (_guns != null)
            foreach (IGun gun in _guns)
                gun.Fire();
    }

    public virtual void DieHandler()
    {
        //Intanciar explocion;
        gameObject.SetActive(false);
    }


}
