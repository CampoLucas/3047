using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossGun : SingleStraightShotGun
{
    private float _initFireRate;

    private void Start()
    {
        _initFireRate = _fireRate;
    }

    public void ChangeFireRate(float rate) => _fireRate = _initFireRate /= (1 + (rate/100));
}
