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

    protected virtual void Awake()
    {
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
        Bullet e = Instantiate(_bulletPrefab, transform.position, Quaternion.identity);
        e.InitData(transform.right);
    }
}
