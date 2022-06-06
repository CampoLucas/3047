using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraightMovement : MonoBehaviour,IMovable
{
    public StatsSO Stats => _stats;
    [SerializeField] private StatsSO _stats;

    private void Awake()
    {
        if (!_stats)
            _stats = GetComponent<Entity>().Data;
    }

    public void Move(Vector3 direction)
    {
        transform.position +=  _stats.Speed * Time.deltaTime * direction;
    }
}
