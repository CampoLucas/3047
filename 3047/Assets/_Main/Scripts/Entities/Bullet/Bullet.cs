using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : Entity, IProduct<StatsSO>
{
    
    [SerializeField] protected float _timeToRecycle = 2f;
    protected float _recycleTime;
    public Vector3 MoveDirection => _moveDirection;
    [SerializeField] protected Vector3 _moveDirection;
    public Pool _Pool;
    protected ICommand _movementCommand;

    protected virtual void Start()
    {
        InitCmd();
        _recycleTime = 0f;
    }

    protected virtual void Update()
    {
        _movementCommand.Do(); //tiene mas sentido y es mas legible hacer el do aca que en otra clase
        if (_recycleTime > _timeToRecycle)
        {
            _recycleTime = 0f;
            _Pool.Recycle(gameObject);
        }

        _recycleTime += Time.deltaTime;
    }

    public virtual void InitData(Vector3 direction,Vector3 initialPosition, Pool pool)
    {
        _moveDirection = direction;
        _moveDirection.z = 0f;
        transform.position = initialPosition;
        _Pool = pool;
    }     
    public virtual void InitData(Vector3 direction,Vector3 initialPosition, Pool pool, float TimeToRecycle)
    {
        _timeToRecycle = TimeToRecycle;
        _moveDirection = direction;
        _moveDirection.z = 0f;
        transform.position = initialPosition;
        _Pool = pool;
    } 


    protected virtual void InitCmd()
    {
        _movementCommand = new CmdMove(transform, _moveDirection, _stats.Speed);
    }

    protected void OnTriggerEnter(Collider other)
    {
        _Pool.Recycle(gameObject);
    }
}
