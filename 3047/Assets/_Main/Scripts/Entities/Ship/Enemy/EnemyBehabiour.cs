using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehabiour : MonoBehaviour
{
    [Header("Components")]
    private Enemy _enemy;
    void Awake()
    {
        _enemy = GetComponent<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        _enemy.Move(Vector3.left);
    }
}
