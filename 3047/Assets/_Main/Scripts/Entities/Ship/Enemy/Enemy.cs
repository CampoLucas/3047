using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Ship
{
    protected override void Awake()
    {
        base.Awake();
        //if(_damagable)
        //    _damagable.OnDie.AddListener(OnDieListener);
    }

    public override void OnDieListener()
    {
        base.OnDieListener();
        Destroy(gameObject);
    }

    private void Update()
    {
        //Move(-Vector3.right);;
    }
}
