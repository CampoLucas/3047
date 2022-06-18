using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Ship
{
    private AnimationHandler _anim;
    public bool IsBoosting => _isBoosting;
    public bool IsDead => _damagable.IsDead;
    [SerializeField] private bool _isBoosting; 
    [SerializeField] private float _invulnerableTime = 2f; 
    public float moveAmount;
    protected override void Awake()
    {
        base.Awake();
        _anim = GetComponent<AnimationHandler>();
    }

    protected override void Start()
    {
        base.Start();
    }

    public void Boost(bool isBoosting)
    {
        
    }

    public override void TakeDamage(int damage)
    {
        GameManager.instance.ResetMultiplier();
        GameManager.instance._HUD.ResetMultiplierBar();
        
        base.TakeDamage(damage);
        
        if(_anim)
            _anim.ToggleDamage();
    }

    public void SetMoveAmount(float amount) => moveAmount = amount;
    public void Dodge()
    {
       if(_anim)
           _anim.ToggleDodge();
       //set invulnerable for a time in seconds
       if(_damagable)
           _damagable.SetInvulnerable(_invulnerableTime);
    }

    public void UpdateAnimation(Vector2 direction, bool isBoosting)
    {
        if (_anim != null)
            _anim.UpdateAnimValues(direction.x, direction.y, isBoosting);
    }

    public override void OnDieListener()
    {
        base.OnDieListener();
        gameObject.SetActive(false);
        GameManager.instance.GameOver();
        //Destroy(gameObject);
        //play deadAnimation but dont destroy
    }

    public void ResetValues()
    {
        _damagable.ResetValues();
    }
}
