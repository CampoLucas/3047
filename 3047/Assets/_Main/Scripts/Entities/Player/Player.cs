using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class Player : Ship
{
    private AnimationHandler _anim;
    public bool IsBoosting => _isBoosting;
    public bool IsDead => _damageable.IsDead;
    [SerializeField] private bool _isBoosting; 
    [SerializeField] private float _invulnerableTime = 2f; 
    public float moveAmount;
    
    private Dictionary<Weapon, IGun> _gunsDictionary;
    [SerializeField] private Weapon MainGun = Weapon.TripleGun;//arma principal de este player
    private float _currentTime;
    private IGun _equippedGun = null;
    private bool _isPowerUP;
    [SerializeField] private TextMeshProUGUI _coolDownNumUI;
    [Header("Take Damage ScreenShake")]
    public float shakeDuration;
    public float shakeMagnitude;
    protected override void Awake()
    {
        _isPowerUP = false;
        _gunsDictionary = new Dictionary<Weapon, IGun>();
        base.Awake();
        _anim = GetComponent<AnimationHandler>();
        _coolDownNumUI.gameObject.SetActive(false);
    }
    
    protected override void Start()
    {
        base.Start();
        foreach (var t in _guns)
        {
            _gunsDictionary.Add(t.type, t);
        }
        
        ChangeGun(MainGun);

    }

    public override void Fire()
    {
        _equippedGun.Fire();
    }

    private void Update()
    {
        if(!_isPowerUP) return;
        _coolDownNumUI.text = _currentTime.ToString("0");
        _currentTime -= Time.deltaTime;
        if (_currentTime <= 0f)
        {
            ChangeGun(MainGun);
            _currentTime = 0f;
            _isPowerUP = false;
            _coolDownNumUI.gameObject.SetActive(false);
        }
    }

    public void PowerUp(Weapon weapon, float coolDown)
    {
        _isPowerUP = true;
        _currentTime = coolDown;
        _coolDownNumUI.gameObject.SetActive(true);
        ChangeGun(weapon);
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
        _anim.ToggleDamage();
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
       _damageable.SetInvulnerable(_invulnerableTime);
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
        _damageable.ResetValues();
    }
    
}
