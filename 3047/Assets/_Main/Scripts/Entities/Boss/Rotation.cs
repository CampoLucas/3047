using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    [SerializeField]private float _rotationSpeed;
    
    public StatsSO Stats => _stats;
    private StatsSO _stats;

    private Vector3 _direction = Vector3.forward;
    
    private void Awake()
    {
        _stats = GetComponent<Ship>().Data;
        InitStats();
    }

    private void InitStats()
    {
        _rotationSpeed = _stats.Speed;
    }

    public void Rotate() => transform.eulerAngles += _direction * (_rotationSpeed * Time.deltaTime);

    public void ChangeRotationDirection() => _direction *= -1;
    public void IncrementRotationSpeed(float percentage) => _rotationSpeed *= (1 + (percentage/100));
}
