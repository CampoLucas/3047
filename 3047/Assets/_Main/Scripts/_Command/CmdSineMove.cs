using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CmdSineMove : ICommand
{
    private Transform _transform;
    private Vector3 _direction;
    private float _speed;
    private float _frequency;
    private float _amplitude;
    public CmdSineMove(Transform transform, Vector3 direction, float speed, float frequency, float amplitude)
    {
        _transform = transform;
        _direction = direction;
        _speed = speed;
        _frequency = frequency;
        _amplitude = amplitude;
    }
    public void Do()
    {
        Vector3 pos = _transform.position;
        pos +=  _speed * Time.deltaTime * Vector3.right ;
        float y = Mathf.Sin(_transform.position.x * _frequency) * _amplitude *Time.deltaTime;
        _transform.position = pos + y *_speed * Vector3.up;
    }
}
