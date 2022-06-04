using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SingleTargetedGun : SingleStraightShotGun
{
    [SerializeField] private Transform _target;
    protected void Start()
    {
        base.Awake();
        //_target = GameManager.instance._player.transform;
    }

    public override void Fire()
    {
        Vector3 dir = _target.position - transform.position;
        Bullet e = _pool.Use().GetComponent<Bullet>();
        e.transform.parent = bulletsEmptyObject.transform; //To avoid Filling up base Hierarchy with bullets
        e.InitData(dir.normalized ,transform.position, _pool);
    }
}
