using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SineMovement : MonoBehaviour,IMovable
{

    public StatsSO Stats => _stats;
    [SerializeField] private StatsSO _stats;
    public SinValuesSO SineStats => _sineStats;
    [SerializeField] private SinValuesSO _sineStats;

    private float _startPosY;
    //[SerializeField] private float Amplitude;
    //[SerializeField] private float Frequency;

    private void Awake()
    {
        if (!_stats)
            _stats = GetComponent<Entity>().Data;
        if (!_sineStats)
            _sineStats = GetComponent<Enemy>().SineData;
    }

    private void Start()
    {
        _startPosY = transform.position.y;
    }

    public void Move(Vector3 direction)//movimiento sin() se mueve solo para arriva
    {
         Vector3 pos = transform.position;
         pos += direction * (_stats.Speed * Time.deltaTime);

         //float y = Mathf.Sin(transform.position.x * _sineStats.Frequency) * _sineStats.Amplitude *Time.deltaTime;
         //transform.position = pos + Vector3.up * (y * _stats.Speed);
         
         float sin = Mathf.Sin(pos.x * _sineStats.Frequency) * _sineStats.Amplitude;
         pos.y = _startPosY + sin;

         transform.position = pos;

    }
}
