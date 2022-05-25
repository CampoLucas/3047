using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour, IGun
{
    [SerializeField] private float _shootDelay = 0.2f;
    private float _lastShootime;
    private Vector3 _direction;
    private Pool _pool;
    [SerializeField] private GameObject bulletsEmptyObject;//este es para setear el parent de las balas para no llenar la hierarchy

    private void Awake()
    {
        _pool = GetComponent<Pool>();
        _direction = transform.right;//logro lo mismo disparando a transform. right
    }


    private void Update()
    {
        //_direction = (transform.localRotation * Vector3.right).normalized;
    }
    public void Fire()
    {
        if (!(_lastShootime + _shootDelay < Time.time)) return;
        _lastShootime = Time.time;
        Create();
    }

    public Bullet Create()
    {
        Bullet e = _pool.Use().GetComponent<Bullet>();
        e.transform.parent = bulletsEmptyObject.transform; //To avoid Filling up base Hierarchy with bullets
        e.InitData(_direction,transform.position,_pool);
        return e;
    }

    public Bullet[] Create(int quantity)//TODO remover esto o hacerlo Factory
    {
        Bullet[] bullets = new Bullet[quantity];

        for (int i = 0; i < quantity; i++)
        {
            bullets[i] = Create();
        }

        return bullets;
    }
}
