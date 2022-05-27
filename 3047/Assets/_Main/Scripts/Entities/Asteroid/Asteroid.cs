using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Asteroid : Ship
{
    //Now everything is in the same script, that is to make sure everithing works, later I'm going to implement more design patterns
    private Rigidbody _rigidbody;
    private float _size = 1f;
    //The stats in Entity.Data should be multiplied or divided by this number, speed, damage, life, etc.
    //The spawner is going to be the one to asign this number as random between minSize and maxSize.
    //The random values should also be asigned in the spawner
    //It needs the randomization for it to feel natural


    [Header("Random values")] 
    [SerializeField] 
    private float minSize = .5f;
    [SerializeField] 
    private float maxSize = 2f;
    [SerializeField] [Range(0, 360)]
    private float angleX = 360;
    [SerializeField] [Range(0, 360)]
    private float angleY = 360;
    [SerializeField] [Range(0, 360)]
    private float angleZ = 360;
    
    protected override void Awake()
    {
        base.Awake();
        _rigidbody = GetComponent<Rigidbody>();
    }

    protected void Start()
    {
        transform.eulerAngles = new Vector3(Random.value * angleX, Random.value * angleY, Random.value * angleZ);
        transform.localScale = Vector3.one * _size;
    }

    public override void OnDieListener()
    {
        base.OnDieListener();
        //Duplicates into anumber between 2 and 3 half of the size of the asteroid, if it is 3 asteroids 3 times smaller
        Destroy(gameObject);
    }
}
