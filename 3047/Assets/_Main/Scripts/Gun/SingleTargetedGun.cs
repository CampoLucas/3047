using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleTargetedGun : SingleStraightShotGun
{
    [SerializeField] private Transform _target;
    
    public override void Fire()
    {
        Vector3 dir = _target.position - transform.position;
        Bullet e = Instantiate(_bulletPrefab, transform.position, Quaternion.identity);
        e.InitData(dir.normalized);
    }
}
