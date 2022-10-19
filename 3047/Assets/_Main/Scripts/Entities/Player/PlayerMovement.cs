using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour, IMovable
{

    private Player _player;

    public float CurrentSpeed => _currentSpeed;
    [SerializeField] private float _currentSpeed;


    public float MoveAmount => _moveAmount;
    [SerializeField] private float _moveAmount;
    public StatsSO Stats => _stats;
    [SerializeField] private StatsSO _stats;

    public CmdPlayerMove CmdPlayerMovememt => _cmdPlayerMovememt;
    private CmdPlayerMove _cmdPlayerMovememt;

    private void Awake()
    {
        if (_stats == null)
            _stats = GetComponent<Entity>().Data;
        _player = GetComponent<Player>();
        
        InitStats();
    }
    private void Update()
    {
        if (_player.IsBoosting)
            _currentSpeed = (_stats.Speed/2) * _player._moveAmount;
        else
            _currentSpeed = _stats.Speed * _player._moveAmount;
    }

    private void InitStats()
    {
        _currentSpeed = _stats.Speed;
    }

    public void Move(Vector3 direction)
    {
        _cmdPlayerMovememt = new CmdPlayerMove(transform, direction, _currentSpeed);
        _cmdPlayerMovememt.Do();
    }

    
}
