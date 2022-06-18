using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Player : Ship
{
    private AnimationHandler _anim;
    public bool IsBoosting => _isBoosting;
    public bool IsDead => _damagable.IsDead;
    [SerializeField] private bool _isBoosting; 
    [SerializeField] private float _invulnerableTime = 2f; 
    public float moveAmount;
    
    private Dictionary<Weapon, IGun> _gunsDictionary;
    private IGun _equippedGun = null;
    
    [Header("Take Damage ScreenShake")]
    public float shakeDuration;
    public float shakeMagnitude;
    protected override void Awake()
    {
        
        _gunsDictionary = new Dictionary<Weapon, IGun>();
        base.Awake();
        _anim = GetComponent<AnimationHandler>();
    }
    
    protected override void Start()
    {
        base.Start();
        foreach (var t in _guns)
        {
            _gunsDictionary.Add(t.type, t);
        }
        
        _equippedGun = _gunsDictionary[Weapon.TripleGun];

    }

    public override void Fire()
    {
        _equippedGun.Fire();
    }

    public void Boost(bool isBoosting)
    {
        
    }
    
    public void ChangeGun(Weapon weapon)
    {
        if(!_gunsDictionary.ContainsKey(weapon)) return; //si no existe el arma en el diccionario then return
        _equippedGun = _gunsDictionary[weapon];
    }
    
    public override void TakeDamage(int damage)
    {
        GameManager.instance.ResetMultiplier();
        GameManager.instance._HUD.ResetMultiplierBar();
        
        ScreenShake.instance.StartShake(shakeDuration,shakeMagnitude);//CameraShake
        
        base.TakeDamage(damage);
    }

    public void SetMoveAmount(float amount) => moveAmount = amount;
    public void Dodge()
    {
       //play dodge anim
       if(_anim)
           _anim.ToggleDodge();
       //set invulnerable for a time in seconds
       //ToDo: Dodge animation were at the begining calls to a SetInvulnerable(true) an at the end SetInvulnerable(false)
       _damagable.SetInvulnerable(_invulnerableTime);
    }

    public void UpdateAnimation(Vector2 direction, bool isBoosting)
    {
        if (_anim)
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
