using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySineMovement : MonoBehaviour,IMovable
{

    public StatsSO Stats => _stats;
    [SerializeField] private StatsSO _stats;
    [SerializeField] private float Amplitude;
    [SerializeField] private float Frequency;

    public void Move(Vector3 direction)//movimiento sin() se mueve solo para arriva
    {
         Vector3 pos = transform.position;
         pos += direction * _stats.Speed * Time.deltaTime;
         float y = Mathf.Sin(transform.position.x * Frequency) * Amplitude *Time.deltaTime;
         transform.position = pos + Vector3.up * y *_stats.Speed;
    }
}
