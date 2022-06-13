using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    public StatsSO Stats => _stats;
    private StatsSO _stats;

    private Vector3 _direction = Vector3.forward;
    
    private void Awake()
    {
        _stats = GetComponent<Ship>().Data;
    }

    public void Rotate() => transform.eulerAngles += _direction * (_stats.Speed * Time.deltaTime);

    public void ChangeRotationDirection() => _direction *= -1;
}
