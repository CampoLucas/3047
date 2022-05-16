using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : Stats
{
    public StatsSO Data => _stats;
    [SerializeField] private StatsSO _stats;

    private IMovable _movable;
    private IFireable[] _guns;
    private IAnimation _anim;

    private void Awake()
    {
        _movable = GetComponent<IMovable>();
        _guns = GetComponentsInChildren<IFireable>();
        _anim = GetComponent<IAnimation>();
    }

    public void Move(Vector3 direction)
    {
        if (_movable != null)
            _movable.Move(direction);
        if (_anim != null)
            _anim.UpdateAnimValues(direction.x, direction.y);
    }

    public void Boost(bool boost)
    {
       
    }

    public void Fire()
    {
        if (_guns != null)
            foreach (IFireable gun in _guns)
                gun.Fire();
    }

    public void Dodge()
    {
       
    }
}
