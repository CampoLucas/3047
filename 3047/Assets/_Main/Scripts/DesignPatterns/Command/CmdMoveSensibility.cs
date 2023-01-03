using UnityEngine;

/// <summary>
/// Noticeable only when playing with a gamepad
/// The velocity depends on how far the joystick is
/// </summary>
public class CmdMoveSensibility : ICommand
{
    private Transform _transform;
    private Vector3 _direction;
    private float _speed;
    private float _moveAmount;

    public CmdMoveSensibility(Transform transform, Vector3 direction, float speed, float moveAmount)
    {
        _transform = transform;
        _direction = direction;
        _speed = speed;
        _moveAmount = moveAmount;
    }
    
    /// <summary>
    /// moves the target using transform, the speed is multiplied with the move amount
    /// </summary>
    public virtual void Do()
    {
        _transform.position += _direction * (_speed * _moveAmount * Time.deltaTime);
    }
}
