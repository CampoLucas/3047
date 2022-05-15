using UnityEngine;

[CreateAssetMenu(fileName = "Stats", menuName = "Entities/Stats", order = 0)]
public class StatsSO : ScriptableObject
{
    public int MaxLife => _stats.MaxLife;
    public float Speed => _stats.Speed;
    public int Damage => _stats.Damage;

    [SerializeField] private StatValues _stats;
}
[System.Serializable]
public struct StatValues
{
    public int MaxLife => _maxLife;
    [SerializeField] private int _maxLife;

    public float Speed => _speed;
    [SerializeField] private float _speed;
    public int Damage => _damage;
    [SerializeField] private int _damage;
}