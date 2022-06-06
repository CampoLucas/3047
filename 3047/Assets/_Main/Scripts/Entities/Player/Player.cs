using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Ship
{
    private IAnimation _anim;
    private IFuel _fuel;
    private Animator _animator;
    public bool IsBoosting => _isBoosting;
    public bool IsDead => _damagable.IsDead;
    [SerializeField] private bool _isBoosting; 
    [SerializeField] private float _invulnerableTime = 2f; 
    public float _moveAmount;
    protected override void Awake()
    {
        base.Awake();
        _anim = GetComponent<IAnimation>();
        _fuel = GetComponent<IFuel>();
        _animator = GetComponent<Animator>();
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
       //play dodge anim
       _animator.SetTrigger("Dodge");//si queres sacarlo no hay problema
       //set invulnerable for a time in seconds
       _damagable.SetInvulnerable(_invulnerableTime);
    }

    public void UpdateAnimation(Vector2 direction, bool isBoosting)//TODO preguntar para que esto y why no settrigger / setbool
    {
        if (_anim != null)
            _anim.UpdateAnimValues(direction.x, direction.y, isBoosting);
    }

    public override void OnDieListener()
    {
        base.OnDieListener();
        //Destroy(gameObject);
        //play deadAnimation but dont destroy
    }

    public void ResetValues()
    {
        _damagable.ResetValues();
    }
}
