using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Bullets", menuName = "Entities/Bullets", order = 0)]
public class BulletSO : ScriptableObject
{
    public float LifeTime => _lifeTime;
    [SerializeField] private float _lifeTime;
    public int Damage => _damage;
    [SerializeField] private int _damage;
    public float Speed => _speed;
    [SerializeField] private float _speed; 
}
