using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleStraightShotGun : MonoBehaviour,IGun
{
    [SerializeField] private float _fireRate = 0.2f;
    private float _lastShootime;
    public Bullet Product => _bulletPrefab;
    [SerializeField] private Bullet _bulletPrefab;

    private void Awake()
    {
        _lastShootime = 0f;
    }

    private void Update()
    {
        if (_lastShootime > _fireRate)
        {
            Fire();
            _lastShootime = 0f;
        }

        _lastShootime += Time.deltaTime;
    }

    public void Fire()
    {
        Bullet e = Instantiate(_bulletPrefab, transform.position, Quaternion.identity);
        e.InitData(transform.right);
    }
}
