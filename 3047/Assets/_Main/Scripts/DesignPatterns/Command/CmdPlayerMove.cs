using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CmdPlayerMove : ICommand
{
    private Transform _transform;
    private Vector3 _direction;
    private float _speed;
    private float _moveAmount;

    public CmdPlayerMove(Transform transform, Vector3 direction, float speed, float moveAmount)
    {
        _transform = transform;
        _direction = direction;
        _speed = speed;
        _moveAmount = moveAmount;
    }

    public virtual void Do()
    {
        _transform.position += _direction * (_speed * _moveAmount * Time.deltaTime);
    }
}
