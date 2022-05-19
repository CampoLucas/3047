using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireable : MonoBehaviour, IFireable
{
    public Bullet Product => _bulletPrefab;
    [SerializeField] private Bullet _bulletPrefab;

    [SerializeField] private float _shootDelay = 0.2f;
    private float _lastShootime;

    private Vector3 _direction;

    private void Update()
    {
        _direction = (transform.localRotation * Vector3.right).normalized;
    }
    public void Fire()
    {
        if (!(_lastShootime + _shootDelay < Time.time)) return;
        _lastShootime = Time.time;
        if (_bulletPrefab != null)
            Create();
    }

    public Bullet Create()
    {
        Bullet e = Instantiate(_bulletPrefab, transform.position, Quaternion.identity);
        e.InitData(_direction);

        return e;
    }

    public Bullet[] Create(int quantity)
    {
        Bullet[] bullets = new Bullet[quantity];

        for (int i = 0; i < quantity; i++)
        {
            bullets[i] = Create();
        }

        return bullets;
    }
}
