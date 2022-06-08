using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Damageable : MonoBehaviour, IDamageable, IObservable
{
    public int CurrentLife => _currentLife;
    [SerializeField] protected int _currentLife;
    
    
    public bool IsDead => _isDead;
    private bool _isDead = false;
    public bool IsInvulnerable => _isInvulnerable; //Quiero que el player tenga unos segundos de inmortalidad cuando le disparen y esquive
    [SerializeField] private bool _isInvulnerable;

    private float _invulnerableTime;
    private float _currentInvulnerableTime;

    public StatsSO Stats => _stats;
    [SerializeField] private StatsSO _stats;

    public List<IObserver> Subscribers => _subscribers;
    private List<IObserver> _subscribers = new List<IObserver>();

    //events

    public Action<int> OnLifeUpdate;
    public UnityEvent OnDie = new UnityEvent();
    
    protected virtual void Awake()
    {
        if (_stats == null)
            _stats = GetComponent<Entity>().Data;
        InitStats();
    }
    private void InitStats() //privado porque solo se deveria llamar en Awake, por eso el nombre Initialize Stats
    {
        _isDead = false;
        _currentLife = _stats.Life;
        _isInvulnerable = false;
    }

    private void Update()
    {
        if (_isInvulnerable)
        {
            _currentInvulnerableTime += Time.deltaTime;
            if (_currentInvulnerableTime >= _invulnerableTime)
            {
                _isInvulnerable = false;
                _currentInvulnerableTime = 0f;
            }
        }
    }

    public virtual void TakeDamage(int damage)
    {
        if(_isInvulnerable) return;
        if (_isDead) return;
        
        _currentLife -= damage;
        if(_currentLife <= 0)
        {
            _currentLife = 0;
            Die();
        }
        OnLifeUpdate?.Invoke(_currentLife);
    }
    public virtual void AddLife(int HP)
    {
        if(_isDead) return;
        
        _currentLife += HP;
        if (_currentLife >= _stats.Life)
            _currentLife = _stats.Life;
        OnLifeUpdate?.Invoke(_currentLife);
    }

    public virtual void SetInvulnerable(float time)
    {
        if(_isDead) return;
        
        _invulnerableTime = time;
        _isInvulnerable = true;
        _currentInvulnerableTime = 0f;
    }

    public void Die()
    {
        _isDead = true;
        OnDie?.Invoke();
    }

    public void ResetValues()
    {
        InitStats();   
    }

    public void Subscribe(IObserver observer)
    {
        if (_subscribers.Contains(observer)) return;
        _subscribers.Add(observer);
    }

    public void Unsubscribe(IObserver observer)
    {
        if (_subscribers.Contains(observer)) return;
        _subscribers.Remove(observer);
    }

    public void NotifyAll(string message, params object[] args)
    {
        foreach (var subscriber in _subscribers)
            subscriber.OnNotify(message, args);
    }

}
