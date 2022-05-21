using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Ship
{
    private IAnimation _anim;

    public bool IsBoosting => _isBoosting;
    [SerializeField] private bool _isBoosting; 
    protected override void Awake()
    {
        base.Awake();
        _anim = GetComponent<IAnimation>();
    }

    public void Boost(bool isBoosting) => _isBoosting = isBoosting;
    public void Dodge()
    {
       
    }
    public void UpdateAnimation(Vector2 direction)
    {
        if (_anim != null)
            _anim.UpdateAnimValues(direction.x, direction.y);
    }
}
