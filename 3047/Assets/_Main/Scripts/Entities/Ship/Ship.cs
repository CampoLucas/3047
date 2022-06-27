using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : Entity
{
    protected IGun[] _guns;
    
    public Damageable Damageable => _damageable;
    [SerializeField] protected Damageable _damageable;

    
    
    protected override void Awake()
    {
        base.Awake();
        _guns = GetComponentsInChildren<IGun>();
    }

    protected override void Start()
    {
        base.Start();
        _damageable = GetComponent<Damageable>();
        if (_damageable)
            _damageable.OnDie.AddListener(OnDieListener);
    }

    public virtual void TakeDamage(int damage)
    {
        if(_damageable)
            _damageable.TakeDamage(damage);
        
        
    }

    public virtual void AddLife(int life)
    {
        if(_damageable)
            _damageable.AddLife(life);
    }

    public virtual void Fire()
    {
        if (_guns != null)
            foreach (IGun gun in _guns)
                gun.Fire();
    }

    public virtual void OnDieListener()
    {
        //Intanciar explocion;
        gameObject.SetActive(false);
    }


}
