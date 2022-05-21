using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour, IMovable
{

    public float Speed => _speed;
    [SerializeField] private float _speed;

    public StatsSO Stats => _stats;
    [SerializeField] private StatsSO _stats;

    public CmdPlayerMove CmdPlayerMovememt => _cmdPlayerMovememt;
    private CmdPlayerMove _cmdPlayerMovememt;

    private void Awake()
    {
        if (_stats == null)
            _stats = GetComponent<Entity>().Data;
        
        
        InitStats();
        if (_stats == null)
            Debug.Log("null stats");
    }

    private void InitStats()
    {
        _speed = _stats.Speed;
    }

    public void Move(Vector3 direction)
    {
        _cmdPlayerMovememt = new CmdPlayerMove(transform, direction, _speed);
        _cmdPlayerMovememt.Do();
    }
}
