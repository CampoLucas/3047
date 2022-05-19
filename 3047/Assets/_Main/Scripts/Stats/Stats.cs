using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    public int MaxLife => _maxLife;
    [SerializeField] protected int _maxLife;

    public float Speed => _speed;
    [SerializeField] protected float _speed;

    public int Damage => _damage;
    [SerializeField] protected int _damage;
}
