using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStraightMove : MonoBehaviour,IMovable
{
    public StatsSO Stats => _stats;
    [SerializeField] private StatsSO _stats;
    public void Move(Vector3 direction)
    {
        transform.position += direction * _stats.Speed * Time.deltaTime;
    }
}
