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
    private void Awake()
    {
        _direction = transform.right;
    }
    
    
    public void Fire()
    {
        if (!(_lastShootime + _fireRate < Time.time)) return;
        _lastShootime = Time.time;
        UsePlusPool();
        UseMinusPool();
    }

    private void UsePlusPool()
    {
        SineBullet p = _plusPool.Use().GetComponent<SineBullet>();
        p.InitData(_direction, transform.position, _plusPool);
        p.transform.parent = GameManager.instance.bullets.transform;
    }

    private void UseMinusPool()
    {
        SineBullet m = _minusPool.Use().GetComponent<SineBullet>();
        m.InitData(_direction,transform.position,_minusPool);
        m.transform.parent = GameManager.instance.bullets.transform;
    }
}
