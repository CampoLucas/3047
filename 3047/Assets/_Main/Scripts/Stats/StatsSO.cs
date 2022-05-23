using UnityEngine;

[CreateAssetMenu(fileName = "Stats", menuName = "Entities/Stats", order = 0)]
public class StatsSO : ScriptableObject
{
    public int MaxLife => _stats.MaxLife;
    public float Speed => _stats.Speed;
    public int Damage => _stats.Damage;

    public float Fuel => _thruster.Fuel;
    public float CombustSpeed => _thruster.CombustionSpeed;
    public float RechargeSpeed => _thruster.RechargeSpeed;
    public float ThrustSpeed => _thruster.ThrustSpeed;

    [SerializeField] private StatValues _stats;
    [SerializeField] private ThrusterValues _thruster;
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
[System.Serializable]
public struct ThrusterValues
{
    public float Fuel => _fuel;
    [SerializeField] private float _fuel;
    public float CombustionSpeed => _combustionSpeed;
    [SerializeField] private float _combustionSpeed;

    public float RechargeSpeed => _rechargeSpeed;
    [SerializeField] private float _rechargeSpeed;
    public float ThrustSpeed => _thrustBoost;
    [SerializeField] private float _thrustBoost;
}