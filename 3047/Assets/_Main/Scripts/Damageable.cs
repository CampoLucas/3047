using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Damageable : MonoBehaviour, IDamagable
{
    public StatsSO Data => _stats;
    [SerializeField] private StatsSO _stats;
    public int CurrentLife => _currentLife;
    [SerializeField] protected int _currentLife;

    public bool IsInvulnerable => _isInvulnerable; //Quiero que el player tenga unos segundos de inmortalidad cuando le disparen y esquive
    private bool _isInvulnerable;

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
        _currentLife = _stats.MaxLife;
    }

    public virtual void TakeDamage(int damage)
    {
        _currentLife -= damage;
        if(_currentLife <= 0)
        {
            _currentLife = 0;
            Die();
        }
        OnLifeUpdate?.Invoke(_currentLife);

        //if (_currentLife > 0 )
        //{
        //    _currentLife -= damage;
        //}
        //OnLifeChange?.Invoke(_currentLife);
        //if (_currentLife <= 0)
        //{
        //    DieHandler();
        //}
    }
    public virtual void AddLife(int HP)
    {
        _currentLife += HP;
        
        //Lo hice asi, porque de esa otra manera, si tu vida esta a 90 y hay un item que te suma 30 de vida, tu vida seguiria en 90 en vez de volver a 100 (Si es que MaxLife es 100) y por eso lo hago asi
        //Tambien combiene usar un mayor igual para que ocupe cualquier numero mayor a max life. 
        //Tambien de esta manera se usa un solo if;
        if (_currentLife >= _stats.MaxLife)
            _currentLife = _stats.MaxLife;
        OnLifeUpdate?.Invoke(_currentLife);


        //if (_currentLife == _stats.MaxLife)
        //{
        //    return;
        //}
        //_currentLife += healnum;
        //OnLifeChange?.Invoke(_currentLife);
        //if (_currentLife > _stats.MaxLife)
        //{
        //    _currentLife = _stats.MaxLife;
        //}
    }
    public void Die() => OnDie?.Invoke();
    public int GetLifePercentage() => _currentLife / _stats.MaxLife;
}
