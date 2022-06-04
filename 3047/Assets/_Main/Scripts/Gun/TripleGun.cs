using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TripleGun : MonoBehaviour, IGun
{
    [SerializeField] private float _shootDelay = 0.2f;
    [SerializeField] private float _fireAngle = 10f;
    [SerializeField] private Transform _shootpoint0;
    [SerializeField] private Transform _shootpoint1;
    private float _lastShootime;
    private Vector3 _direction;
    private Pool _pool;
    private GameObject bulletsEmptyObject;

    private void Awake()
    {
        bulletsEmptyObject = new GameObject
        {
            name = "Bullets"
        };
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

    public void Create()
    {
        Bullet e0 = _pool.Use().GetComponent<Bullet>();
        e0.transform.parent = bulletsEmptyObject.transform; //To avoid Filling up base Hierarchy with bullets
        e0.InitData(_direction.normalized,transform.position,_pool);       
        
        Bullet e1 = _pool.Use().GetComponent<Bullet>();
        e1.transform.parent = bulletsEmptyObject.transform;
        _direction = _shootpoint0.transform.right;
        e1.InitData(_direction.normalized, transform.position,_pool);
        
        Bullet e2 = _pool.Use().GetComponent<Bullet>();
        e2.transform.parent = bulletsEmptyObject.transform; 
        _direction = _shootpoint1.transform.right;
        e2.InitData(_direction.normalized,transform.position,_pool);
        
        _direction = transform.right;
    }
}
