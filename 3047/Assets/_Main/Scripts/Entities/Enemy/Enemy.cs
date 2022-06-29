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
    
    Camera cam;
    Vector2 screenSize;
    
    protected override void Awake()
    {
        base.Awake();
        //if(_damagable)
        //    _damagable.OnDie.AddListener(OnDieListener);
        cam = Camera.main;
        GetScreenSize();
    }
    private void GetScreenSize() => screenSize = new Vector2((1 / (cam.WorldToViewportPoint(new Vector3(1, 1, 0)).x - .5f)) / 2, (1 / (cam.WorldToViewportPoint(new Vector3(1, 1, 0)).y - .5f)) / 2);

    private void Update()
    {
        //cuando se salen del borde izquierdo de la pantalla se llama al ondie
        Vector3 pos = transform.position;
        if (pos.x <= -screenSize.x) _damageable.OnDie.Invoke();
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
