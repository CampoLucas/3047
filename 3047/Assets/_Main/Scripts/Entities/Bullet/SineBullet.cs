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

    protected override void Update()
    {
        base.Update();
    }

    protected override void InitCmd()
    {
        _movementCommand = new CmdSineMove(transform, _moveDirection, _stats.Speed,
            _sinValues.Frequency, _sinValues.Amplitude);
    }
}
