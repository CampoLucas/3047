using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleStraightShotGun : MonoBehaviour,IGun
{
    [SerializeField] private float _fireRate = 0.2f;
    private float _lastShootime;
    public Bullet Product => _bulletPrefab;
    [SerializeField] protected Bullet _bulletPrefab;
    protected Pool _pool;
    
    protected virtual void Awake()
    {
        _pool = GetComponentInParent<Pool>();
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
        Vector3 position = transform.position;
        Bullet e = Instantiate(_bulletPrefab, position, Quaternion.identity);
        e.InitData(transform.right,position,_pool);
    }
}
