using UnityEngine;

[CreateAssetMenu(fileName = "Stats", menuName = "Entities/Stats", order = 0)]
public class StatsSO : ScriptableObject
{
    public int MaxLife => _maxLife;
    [SerializeField] private int _maxLife;

    public float Speed => _speed;
    [SerializeField] private float _speed; 
    
    public float SlowSpeed => _slowSpeed;
    [SerializeField] private float _slowSpeed;
    

}
