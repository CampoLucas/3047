using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SineBullets : MonoBehaviour, IProduct<StatsSO>
{
    public StatsSO Data { get; }
    [SerializeField] private StatsSO _stats;
    [SerializeField] private float Amplitude;
    [SerializeField] private float Frequency;
    private void Awake()
    {
        Destroy(gameObject,3f);
    }

    private void Update()
    {
        Vector3 pos = transform.position;
        pos += Vector3.right * _stats.Speed * Time.deltaTime;
        float y = Mathf.Sin(transform.position.x * Frequency) * Amplitude *Time.deltaTime;
        transform.position = pos + Vector3.up * y *_stats.Speed;
    }
}
