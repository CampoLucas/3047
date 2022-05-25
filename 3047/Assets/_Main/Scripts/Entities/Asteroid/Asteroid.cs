using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : Ship
{
    protected override void Awake()
    {
        base.Awake();
    }
    public override void OnDieListener()
    {
        base.OnDieListener();
        //Duplicates into anumber between 2 and 3 half of the size of the asteroid, if it is 3 asteroids 3 times smaller
        Destroy(gameObject);
    }
}
