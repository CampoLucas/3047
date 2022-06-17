using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Player : Ship
{
    private IAnimation _anim;
    private Animator _animator;
    public bool IsBoosting => _isBoosting;
    public bool IsDead => _damagable.IsDead;
    [SerializeField] private bool _isBoosting; 
    [SerializeField] private float _invulnerableTime = 2f; 
    public float _moveAmount;
    
    private Dictionary<Weapon, IGun> _gunsDictionary;
    private IGun EquippedGun = null;
    
    [Header("Take Damage ScreenShake")]
    public float ShakeDuration;
    public float ShakeMagnitude;
    protected override void Awake()
    {
        
        _gunsDictionary = new Dictionary<Weapon, IGun>();
        base.Awake();
        _anim = GetComponent<IAnimation>();
        _animator = GetComponent<Animator>();
    }
    
    protected override void Start()
    {
        base.Start();
        foreach (var t in _guns)
        {
            _gunsDictionary.Add(t.type, t);
        }
        
        EquippedGun = _gunsDictionary[Weapon.TripleGun];

    }

    public override void Fire()
    {
        EquippedGun.Fire();
    }

    public void Boost(bool isBoosting)
    {
        
    }
    
    public void ChangeGun(Weapon weapon)
    {
        if(!_gunsDictionary.ContainsKey(weapon)) return;
        EquippedGun = _gunsDictionary[weapon];
    }
    
    public override void TakeDamage(int damage)
    {
        GameManager.instance.ResetMultiplier();
        GameManager.instance._HUD.ResetMultiplierBar();
        
        ScreenShake.instance.StartShake(ShakeDuration,ShakeMagnitude);//CameraShake
        
        base.TakeDamage(damage);
    }

    public void SetMoveAmount(float moveAmount) => _moveAmount = moveAmount;
    public void Dodge()
    {
       //play dodge anim
       _animator.SetTrigger("Dodge");//si queres sacarlo no hay problema
       //set invulnerable for a time in seconds
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUP")) //TODO CAmbiar esto por un getcomponent del powerup
        {
            ChangeGun(Weapon.HelixGun);
        }
    }
}
