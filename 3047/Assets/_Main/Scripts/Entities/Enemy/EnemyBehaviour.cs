using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] protected Enemy _enemy;
    protected virtual void Awake()
    {
        _enemy = GetComponent<Enemy>();
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        _enemy.Move(Vector3.left);
    }
}
