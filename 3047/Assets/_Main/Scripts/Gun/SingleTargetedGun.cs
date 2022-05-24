using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SingleTargetedGun : SingleStraightShotGun
{
    [SerializeField] private Transform _target;
    
    
    public override void Fire()
    {
        Vector3 position = transform.position;
        Vector3 dir = _target.position - position;
        Bullet e = Instantiate(_bulletPrefab, position, Quaternion.identity);
        e.InitData(dir.normalized, position, _pool);
    }
}
