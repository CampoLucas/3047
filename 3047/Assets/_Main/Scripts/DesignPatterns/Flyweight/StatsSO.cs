using UnityEngine;

[CreateAssetMenu(fileName = "Stats", menuName = "Entities/Stats", order = 0)]
public class StatsSO : ScriptableObject
{
    public string Id => _id;
    public int Life => _life;
    public float Speed => _speed;
    public int Damage => _damage;
    [SerializeField] private string _id = "def";
    [SerializeField] private int _life = 100;
    [SerializeField] private float _speed = 10;
    [SerializeField] private int _damage = 5;
}
