using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelixGun : MonoBehaviour,IGun
{
    [SerializeField] private float _fireRate = 0.2f;
    private float _lastShootime;
    public SineBullets Product => _bulletPrefabPlus;
    [SerializeField] protected SineBullets _bulletPrefabPlus;
    [SerializeField] protected SineBullets _bulletPrefabMinus;

    private void Awake()
    {
        _lastShootime = 0f;
    }

    private void Update()
    {
        _lastShootime += Time.deltaTime;
    }

    public void Fire()
    {
        if (_lastShootime > _fireRate)
        {
            Instantiate(_bulletPrefabPlus, transform.position, Quaternion.identity);
            Instantiate(_bulletPrefabMinus, transform.position, Quaternion.identity);
            _lastShootime = 0f;
        }
    }
}
