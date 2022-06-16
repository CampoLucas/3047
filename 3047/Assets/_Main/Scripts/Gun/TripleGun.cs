using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TripleGun : MonoBehaviour, IGun
{
    [SerializeField] private float _shootDelay = 0.2f;
    [SerializeField] private Transform _shootpoint0;
    [SerializeField] private Transform _shootpoint1;
    [SerializeField] private float _bulletLifeTime = 1f;
    [SerializeField] private ParticleSystem _muzzleFlash;
    private float _lastShootime;
    private Vector3 _direction;
    private Pool _pool;

    private void Awake()
    {
        _pool = GetComponent<Pool>();
        _direction = transform.right;//logro lo mismo disparando a transform. right
    }

    private void Start()
    {
        _muzzleFlash = GetComponentInChildren<ParticleSystem>();
    }

    private void Update()
    {
        //_direction = (transform.localRotation * Vector3.right).normalized;
    }
    public void Fire()
    {
        if (!(_lastShootime + _shootDelay < Time.time)) return;
        _lastShootime = Time.time;
        _muzzleFlash.Play();
        Create();
    }

    public void Create()
    {
        Bullet e0 = _pool.Use().GetComponent<Bullet>();
        e0.transform.parent = GameManager.instance.bullets.transform;//To avoid Filling up base Hierarchy with bullets
        _direction = transform.right;
        e0.InitData(_direction.normalized,transform.position,_pool,_bulletLifeTime);       
        
        Bullet e1 = _pool.Use().GetComponent<Bullet>();
        e1.transform.parent = GameManager.instance.bullets.transform;
        _direction = _shootpoint0.transform.right;
        e1.InitData(_direction.normalized, transform.position,_pool,_bulletLifeTime);
        
        Bullet e2 = _pool.Use().GetComponent<Bullet>();
        e2.transform.parent = GameManager.instance.bullets.transform; 
        _direction = _shootpoint1.transform.right;
        e2.InitData(_direction.normalized,transform.position,_pool,_bulletLifeTime);
        
        _direction = transform.right;
    }
}
