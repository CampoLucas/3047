using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelixGun : MonoBehaviour,IGun
{
    [SerializeField] private float _fireRate = 0.2f;
    private float _lastShootime;
    [SerializeField] private Pool _plusPool;
    [SerializeField] private Pool _minusPool;
    private Vector3 _direction;
    private GameObject bulletsEmptyObject;// este es para setear el parent de las bullets
    private void Awake()
    {
        bulletsEmptyObject = new GameObject
        {
            name = "Bullets"
        };
        _lastShootime = 0f;
        _direction = transform.right;
    }

    private void Update()
    {
        _lastShootime += Time.deltaTime;
    }

    public void Fire()
    {
        if (_lastShootime > _fireRate)
        {
            UsePlusPool();
            UseMinusPool();
            _lastShootime = 0f;
        }
    }

    private SineBullet UsePlusPool()
    {
        SineBullet p = _plusPool.Use().GetComponent<SineBullet>();
        p.InitData(_direction, transform.position, _plusPool);
        p.transform.parent = bulletsEmptyObject.transform;
        return p;
    }

    private SineBullet UseMinusPool()
    {
        SineBullet m = _minusPool.Use().GetComponent<SineBullet>();
        m.InitData(_direction,transform.position,_minusPool);
        m.transform.parent = bulletsEmptyObject.transform;
        return m;
    }
}
