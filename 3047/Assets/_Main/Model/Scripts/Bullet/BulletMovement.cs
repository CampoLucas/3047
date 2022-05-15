using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    private Bullet _bullet;
    private void Awake()
    {
        _bullet = GetComponent<Bullet>();
    }

    private void Update()
    {
        Move();
    }
    public void Move()
    {
        _bullet.MovemetCommand.Do();
    }
}
