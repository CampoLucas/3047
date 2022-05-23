using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Ship
{
    private IAnimation _anim;
    private IFuel _fuel;

    public bool IsBoosting => _isBoosting;
    [SerializeField] private bool _isBoosting; 
    public float _moveAmount;
    protected override void Awake()
    {
        base.Awake();
        _anim = GetComponent<IAnimation>();
        _fuel = GetComponent<IFuel>();
    }

    public void Boost(bool isBoosting)
    {
        if (_fuel != null && _fuel.HasFuel)
        {
            _isBoosting = isBoosting;
        }
        else if (_fuel != null && !_fuel.HasFuel)
        {
            _isBoosting = false;
        }
        else
            _isBoosting = isBoosting;
    }

    public void SetMoveAmount(float moveAmount) => _moveAmount = moveAmount;
    public void Dodge()
    {
       
    }

    public void CombustFuel()
    {
        if (_fuel != null)
            _fuel.CombustFuel();
    }

    public void CombustFuel(float speed)
    {
        if (_fuel != null)
            _fuel.CombustFuel(speed);
    }

    public void RefillFuel()
    {
        if (_fuel != null)
            _fuel.RefillFuel();
    }

    public void RechargeFuel(float speed)
    {
        if (_fuel != null)
            _fuel.RefillFuel(speed);
    }

    public void UpdateAnimation(Vector2 direction, bool isBoosting)
    {
        if (_anim != null)
            _anim.UpdateAnimValues(direction.x, direction.y, isBoosting);
    }
}
