using UnityEngine;

[CreateAssetMenu(fileName = "Stats", menuName = "Entities/Stats", order = 0)]
public class StatsSO : ScriptableObject
{
    public string Id => _id;
    [SerializeField] private string _id = "def";
    public int Life => _life;
    [SerializeField] private int _life = 100;
    public float Speed => _speed;
    [SerializeField] private float _speed = 10;
    public int Damage => _damage;
    [SerializeField] private int _damage = 5;
}
