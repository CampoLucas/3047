using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerMovement : MonoBehaviour, IMovable
{

    private Player _player;
    private StatsSO _stats;
    private CmdPlayerMove _cmdPlayerMovememt;

    private void Awake()
    {
        if (_stats == null)
            _stats = GetComponent<Entity>().Data;
        _player = GetComponent<Player>();
    }

    public void Move(Vector3 direction)
    {
        _cmdPlayerMovememt = new CmdPlayerMove(transform, direction, _stats.Speed, _player.GetMoveAmount());
        _cmdPlayerMovememt.Do();
    }
}
