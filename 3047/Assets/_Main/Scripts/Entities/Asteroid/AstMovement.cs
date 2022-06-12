using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstMovement : MonoBehaviour, IMovable
{
    private CmdMove _cmdMove;

    [SerializeField] private StatsSO _stats;

    private void Awake()
    {
        _stats = GetComponent<Entity>().Data;
    }

    public void Move(Vector3 direction)
    {
        _cmdMove = new CmdMove(transform, direction, _stats.Speed);
        _cmdMove.Do();
    }
}
