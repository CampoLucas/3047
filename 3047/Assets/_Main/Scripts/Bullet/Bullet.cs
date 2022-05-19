using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : Stats, IProduct<StatsSO>
{
    public StatsSO Data => _stats;
    [SerializeField] private StatsSO _stats;

    public Vector3 MoveDirection => _moveDirection;
    [SerializeField] private Vector3 _moveDirection;

    public CmdMove MovemetCommand => _movementCommand;
    private CmdMove _movementCommand;

    private void Start()
    {
        InitCmd();
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
