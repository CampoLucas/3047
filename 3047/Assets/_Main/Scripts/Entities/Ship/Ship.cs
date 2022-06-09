using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : Entity
{
    private IGun[] _guns;
    [SerializeField] protected Damageable _damagable;

    protected override void Awake()
    {
        base.Awake();
        _guns = GetComponentsInChildren<IGun>();
    }

    protected override void Start()
    {
        base.Start();
        _damagable = GetComponent<Damageable>();
        if (_damagable)
            _damagable.OnDie.AddListener(OnDieListener);
    }

    public virtual void TakeDamage(int damage)
    {
        if(_damagable)
            _damagable.TakeDamage(damage);
        //Debug.Log("damage" + gameObject.name);
    }

    public virtual void AddLife(int life)
    {
        if(_damagable)
            _damagable.AddLife(life);
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
