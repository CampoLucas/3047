using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Damagable : MonoBehaviour, IDamagable
{
    [SerializeField] protected int _maxLife;
    [SerializeField] protected int _currentLife;
    public int CurrentLife => _currentLife;
    public int MaxLife => _maxLife;
    public Action<int> OnLifeChange;//HP y barra de vida
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

        if (_currentLife == _maxLife)
        {
            return;
        }
        _currentLife += healnum;
        OnLifeChange.Invoke(_currentLife);
        if (_currentLife > _maxLife)
        {
            _currentLife = _maxLife;
        }
    }
    public void DieHandler()
    {
        OnDie.Invoke();
    }
    
    public void ResetValues()
    {
        _currentLife = _maxLife;
    }

    public int GetLifePercentage()
    {
        return (int)_currentLife / _maxLife;
    }
}
