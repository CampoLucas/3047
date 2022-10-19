using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleStraightShotGun : MonoBehaviour,IGun
{
    [SerializeField] private float _fireRate = 0.2f;
    private float _lastShootime;
    protected Pool _pool;
    
    protected virtual void Awake()
    {
        _pool = GetComponent<Pool>();
        _lastShootime = 0f;
    }

    protected virtual void Update()
    {
        if (_lastShootime > _fireRate)
        {
            Fire();
            _lastShootime = 0f;
        }

        _lastShootime += Time.deltaTime;
    }

    public virtual void Fire()
    {
        Bullet e = _pool.Use().GetComponent<Bullet>();
        e.transform.parent = GameManager.instance.bullets.transform; //To avoid Filling up base Hierarchy with bullets
        e.InitData(transform.right ,transform.position,_pool);
    }
}
