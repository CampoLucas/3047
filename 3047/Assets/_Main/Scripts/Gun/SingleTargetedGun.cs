using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SingleTargetedGun : SingleStraightShotGun
{
    [SerializeField] private Player _target;
    [SerializeField] private float _range = 3f;
    [SerializeField] private LayerMask _layerMask;
    
    protected void Start()
    {
        _type = Weapon.SingleTargetedGun;
        base.Awake();
        //_target = GameManager.instance._player;
    }

    private void FixedUpdate()
    {
        MyCollision();
    }

    private void MyCollision()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, _range, _layerMask);
        foreach (Collider other in hitColliders)
        {
            Player player = other.GetComponent<Player>();
            if (player)
                _target = player;
            else
                _target = null;
        }
    }

    public override void Fire()
    {
        if (!_target) return;
        if(_target.IsDead) return;
        Vector3 dir = _target.transform.position - transform.position;
        Bullet e = _pool.Use().GetComponent<Bullet>();
        e.transform.parent = GameManager.instance.bullets.transform; //To avoid Filling up base Hierarchy with bullets
        e.InitData(dir.normalized ,transform.position, _pool);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, _range);
    }
}
