using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : Stats, IProduct<StatsSO>
{
    public StatsSO Data => _stats;
    [SerializeField] private StatsSO _stats;

    public Vector3 MoveDirection => _moveDirection;
    [SerializeField] private Vector3 _moveDirection;

    public CmdMove MovementCommand => _movementCommand;
    private CmdMove _movementCommand;

    private void Start()
    {
        InitCmd();
        Destroy(gameObject,3f);//TODO Cambiar por Pool
    }
    
    public void InitData(Vector3 direction)
    {
        _moveDirection = direction;
        _speed = Data.Speed;
        _damage = Data.Damage;
    }

    private void InitCmd()
    {
        _movementCommand = new CmdMove(transform, _moveDirection, _speed);
    }
}
