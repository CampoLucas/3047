using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Enemy : Ship
{
    public SinValuesSO SineData => _sineStats;
    [SerializeField] private SinValuesSO _sineStats;
    
    [SerializeField] private float points = 2f;
    [SerializeField] private float addedMultiplier = 0.02f;
    
    protected override void Awake()
    {
        base.Awake();
        //if(_damagable)
        //    _damagable.OnDie.AddListener(OnDieListener);
        
        
    }


    public override void OnDieListener()
    {
        base.OnDieListener();
        GameManager.instance.AddScore(points);
        GameManager.instance.AddMultiplierCounter(addedMultiplier);
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        
    }
}
