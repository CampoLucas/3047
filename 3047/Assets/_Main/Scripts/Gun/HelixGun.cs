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
    [SerializeField] private GameObject bulletsEmptyObject;// este es para setear el parent de las
                                                           // balas para no llenar la hierarchy
                                                           //Tiene que ser otro game object en la hierarchy base porque
                                                           // si no las balas se mueven junto al player o junto a dicho objeto
    private void Awake()
    {
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
