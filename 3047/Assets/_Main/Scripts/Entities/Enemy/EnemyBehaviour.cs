using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : Ship
{
    
    private void Update()
    {
        Move(-Vector3.right);;
    }
}
