using UnityEngine;

/// <summary>
/// Used to move an object
/// </summary>
public class CmdMove : ICommand
{
    private Transform _transform;
    private Vector3 _direction;
    private float _speed;

    public CmdMove(Transform transform, Vector3 direction, float speed)
    {
        _transform = transform;
        _direction = direction;
        _speed = speed;
    }

    /// <summary>
    /// Moves the object using transform
    /// </summary>
    public virtual void Do()
    {
        _transform.position += Time.deltaTime * _speed * _direction;
    }
}
