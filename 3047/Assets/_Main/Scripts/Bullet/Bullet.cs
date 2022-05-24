using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : Entity, IProduct<StatsSO>
{
    [SerializeField] private float _timeToRecycle = 2f;
    private float _recycleTime;
    public Vector3 MoveDirection => _moveDirection;
    [SerializeField] private Vector3 _moveDirection;
    public Pool _Pool;
    public CmdMove MovementCommand => _movementCommand;
    private CmdMove _movementCommand;

    private void Start()
    {
        InitCmd();
        _recycleTime = 0f;
    }

    private void Update()
    {
        if (_recycleTime>_timeToRecycle)
        {
            _recycleTime = 0f;
            _Pool.Recycle(gameObject);
        }

        _recycleTime += Time.deltaTime;
    }

    public void InitData(Vector3 direction,Vector3 initialPosition, Pool pool)
    {
        _moveDirection = direction;
        transform.position = initialPosition;
        _Pool = pool;
    }

    private void InitCmd()
    {
        _movementCommand = new CmdMove(transform, _moveDirection, _stats.Speed);
    }
}
