using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SineBullet : Bullet
{
    [SerializeField] private SinValuesSO _sinValues;

    protected override void Start()
    {
        InitCmd();
        _recycleTime = 0f;
    }
    
    public override void Move(Vector3 dir)
    {
        _movementCommand = new CmdSineMove(transform, _moveDirection, 10,
            _sinValues.Frequency, _sinValues.Amplitude);
        _movementCommand.Do();
    }

    public override void InitData(Vector3 direction, Vector3 initialPosition, Pool pool)
    {
        _moveDirection = direction;
        _moveDirection.z = 0f;
        transform.position = initialPosition;
        _Pool = pool;
        _movementCommand = new CmdSineMove(transform, _moveDirection, _stats.Speed,
           _sinValues.Frequency, _sinValues.Amplitude);
    }

    protected override void InitCmd()
    {
        _movementCommand = new CmdSineMove(transform, _moveDirection, _stats.Speed,
            _sinValues.Frequency, _sinValues.Amplitude);
    }

    protected override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
    }
}
