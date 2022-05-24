using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelTank : MonoBehaviour, IFuel
{
    private Player _player;    
    public float CurrentFuel => _currentFuel;
    [SerializeField] private float _currentFuel;

    public bool HasFuel
    {
        get
        {
            if (_currentFuel > 0)
                return true;
            else
                return false;
        }
    }

    public StatsSO Stats => _stats;
    [SerializeField] private StatsSO _stats;

    void Awake()
    {
        _player = GetComponent<Player>();
        if (_stats == null)
            _stats = GetComponent<Entity>().Data;
        InitData();
    }
    private void InitData()
    {
        _currentFuel = _stats.Fuel;
    }

    // Update is called once per frame
    void Update()
    {
        if (_player.IsBoosting)
            CombustFuel();
        else
            RefillFuel();
    }

    public void CombustFuel()
    {
        if (CurrentFuel > 0)
            _currentFuel -= 1 * _stats.CombustSpeed * Time.deltaTime;
        else if (_currentFuel < 0)
            _currentFuel = 0;
    }
    public void CombustFuel(float speed)
    {
        if (_currentFuel >= 0)
            _currentFuel -= 1 * speed * Time.deltaTime;
        else if (_currentFuel < 0)
            _currentFuel = 0;
    }
    public void RefillFuel()
    {
        if (_currentFuel < _stats.Fuel)
            _currentFuel += 1 * _stats.RechargeSpeed * Time.deltaTime;
        else if (_currentFuel > _stats.Fuel)
            _currentFuel = _stats.Fuel;
    }
    public void RefillFuel(float speed)
    {
        if (_currentFuel < _stats.Fuel)
            _currentFuel += 1 * speed * Time.deltaTime;
        else if (_currentFuel > _stats.Fuel)
            _currentFuel = _stats.Fuel;
    }
    //public bool HasFuel()
    //{
    //    if (_currentFuel > 0) 
    //        return true;
    //    else 
    //        return false;
    //}
}
