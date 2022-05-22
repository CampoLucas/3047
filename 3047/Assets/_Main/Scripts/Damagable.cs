using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Damagable : MonoBehaviour, IDamagable
{
    public StatsSO Data => _stats;
    [SerializeField] private StatsSO _stats;
    public int CurrentLife => _currentLife;
    [SerializeField] protected int _currentLife;

    public bool IsInvulnerable;
    //events
    public Action<int> OnLifeChange;
    public UnityEvent OnDie = new UnityEvent();
    
    protected virtual void Awake()
    {
        if (_stats == null)
            _stats = GetComponent<Entity>().Data;
        InitStats();
    }
    

    public virtual void TakeDamage(int damage)
    {
        if (_currentLife > 0 )
        {
            _currentLife -= damage;
        }
        OnLifeChange.Invoke(_currentLife);
        if (_currentLife <= 0)
        {
            DieHandler();
        }
    }
    public virtual void AddLife(int healnum)
    {

        if (_currentLife == _stats.MaxLife)
        {
            return;
        }
        _currentLife += healnum;
        OnLifeChange.Invoke(_currentLife);
        if (_currentLife > _stats.MaxLife)
        {
            _currentLife = _stats.MaxLife;
        }
    }
    public void DieHandler()
    {
        OnDie.Invoke();
    }
    
    public void InitStats()
    {
        _currentLife = _stats.MaxLife;
    }

    public int GetLifePercentage()
    {
        return _currentLife / _stats.MaxLife;
    }
}
