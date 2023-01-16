using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A script that handles the life of an objects.
/// </summary>
public class Damageable : MonoBehaviour, IDamageable, IObservable
{
    public List<IObserver> Subscribers { get; private set; }
    private StatsSO _stats;
    
    public event DieDelegate OnDie;
    public event LivesUpdatedDelegate OnLivesUpdated;
    
    [SerializeField] private float invulnerableTime = 2;
    private int _currentLife;
    private bool _isInvulnerable;
    private float _currentInvulnerableTime;

    
    protected virtual void Awake()
    {
        _stats = GetComponent<Entity>().Data;
        InitStats();
    }

    private void Start()
    {
        Subscribers = new List<IObserver>();
    }

    private void InitStats() //privado porque solo se deveria llamar en Awake, por eso el nombre Initialize Stats
    {
        _currentLife = _stats.Life;
        _isInvulnerable = false;
    }

    private void Update()
    {
        if (!_isInvulnerable) return;
        _currentInvulnerableTime += Time.deltaTime;
        if (!(_currentInvulnerableTime >= invulnerableTime)) return;
        _isInvulnerable = false;
        _currentInvulnerableTime = 0f;
    }

    public virtual void TakeDamage(int amount)
    {
        if (_isInvulnerable) return;
        if (!IsAlive()) return;
        
        _currentLife -= amount;
        if (_currentLife <= 0)
        {
            _currentLife = 0;
            OnDie?.Invoke();
        }
        OnLivesUpdated?.Invoke(_currentLife, _stats.Life);
    }
    public virtual void AddLife(int HP)
    {
        if(!IsAlive()) return;
        
        _currentLife += HP;
        if (_currentLife >= _stats.Life)
            _currentLife = _stats.Life;
        OnLivesUpdated?.Invoke(_currentLife, _stats.Life);
    }

    public bool IsAlive() => _currentLife > 0;
    public void Reset() => InitStats();

    //Not uses yet
    public void Subscribe(IObserver observer)
    {
        if (Subscribers.Contains(observer)) return;
        Subscribers.Add(observer);
    }

    public void Unsubscribe(IObserver observer)
    {
        if (Subscribers.Contains(observer)) return;
        Subscribers.Remove(observer);
    }

    public void NotifyAll(string message, params object[] args)
    {
        foreach (var subscriber in Subscribers)
            subscriber.OnNotify(message, args);
    }

}
