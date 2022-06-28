using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTargetBehaviour : EnemyBehaviour
{
    protected override void Update()
    {
        _enemy.Move((transform.rotation * Vector3.left).normalized);
    }
}
