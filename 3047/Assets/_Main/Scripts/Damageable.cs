using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.PlayerLoop;

public class Damageable : MonoBehaviour, IDamageable
{
    public StatsSO Data => _stats;
    [SerializeField] private StatsSO _stats;
    public int CurrentLife => _currentLife;
    [SerializeField] protected int _currentLife;
    public bool IsDead => _isDead;
    private bool _isDead = false;
    public bool IsInvulnerable => _isInvulnerable; //Quiero que el player tenga unos segundos de inmortalidad cuando le disparen y esquive
    private bool _isInvulnerable;
    private float _invulnerabilityTime;
    private float _currentTime;

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
        _currentLife = _stats.MaxLife;
        _isInvulnerable = false;
    }

    private void Update()
    {
        _currentTime += Time.deltaTime;
        if (_isInvulnerable && _currentTime >= _invulnerabilityTime)
        {
            _isInvulnerable = false;
            _currentTime = 0f;
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
        if (_currentLife >= _stats.MaxLife)
            _currentLife = _stats.MaxLife;
        OnLifeUpdate?.Invoke(_currentLife);
    }

    public virtual void SetInvulnerable(float time)
    {
        if(_isDead) return;
        
        _invulnerabilityTime = time;
        _isInvulnerable = true;
        _currentTime = 0f;
    }

    public void Die()
    {
        _isDead = true;
        OnDie?.Invoke();
    }
    public int GetLifePercentage() => _currentLife / _stats.MaxLife;

    public void ResetValues()
    {
        InitStats();   
    }

}
