using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CmdPlayerMove : ICommand
{
    private Transform _transform;
    private Vector3 _direction;
    private float _speed;

    public CmdPlayerMove(Transform transform, Vector3 direction, float speed)
    {
        _transform = transform;
        _direction = direction;
        _speed = speed;
    }

    public void Do()
    {
        Vector3 pos = _transform.position;

        float moveAmount = _speed * Time.deltaTime;

        Vector3 move = Vector3.zero;

        if (_direction.x > 0) move.x += _direction.x + moveAmount;
        if (_direction.x < 0) move.x += _direction.x + moveAmount;
        if (_direction.y > 0) move.y += _direction.y + moveAmount;
        if (_direction.y < 0) move.y += _direction.y + moveAmount;

        float moveMagnitude = Mathf.Sqrt(move.x * move.x + move.y * move.y);
        if (moveMagnitude > moveAmount)
        {
            float ratio = moveAmount / moveMagnitude;
            move *= ratio;
        }

        pos += move;




        _transform.position = pos;
    }

}
