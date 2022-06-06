using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SingleTargetedGun : SingleStraightShotGun
{
    [SerializeField] private Player _target;
    protected void Start()
    {
        base.Awake();
        _target = GameManager.instance._player;
    }

    public override void Fire()
    {
        if(_target.IsDead) return;
        Vector3 dir = _target.transform.position - transform.position;
        Bullet e = _pool.Use().GetComponent<Bullet>();
        e.transform.parent = GameManager.instance.bullets.transform; //To avoid Filling up base Hierarchy with bullets
        e.InitData(dir.normalized ,transform.position, _pool);
    }
}
