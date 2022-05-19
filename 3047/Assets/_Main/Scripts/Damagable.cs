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
    //events
    public Action<int> OnLifeChange;
    public UnityEvent OnDie = new UnityEvent();
    
    protected virtual void Awake()
    {
        ResetValues();
    }
    

    public virtual void GetDamage(int damage)
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
    public virtual void GetHealing(int healnum)
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
    
    public void ResetValues()
    {
        _currentLife = _stats.MaxLife;
    }

    public int GetLifePercentage()
    {
        return _currentLife / _stats.MaxLife;
    }
}
