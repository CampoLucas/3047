using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class Player : Ship
{
    public float shakeDuration;// No creo que deveria estar aca
    public float shakeMagnitude;// No creo que deveria estar aca
    public bool IsDead => _damageable.IsDead;// No creo que deveria estar aca
    
    [SerializeField] private float _invulnerableTime = 2f; 
    [SerializeField] private Weapon MainGun = Weapon.TripleGun;// arma principal de este player
    [SerializeField] private TextMeshProUGUI _coolDownNumUI;// No creo que deveria estar aca
    
    private PlayerInputs _inputs;
    private PlayerAnimaion _anim;
    private Dictionary<Weapon, IGun> _gunsDictionary;// No creo que deveria estar aca
    private float _currentTime;// No creo que deveria estar aca
    private IGun _equippedGun = null;// No creo que deveria estar aca
    private bool _isPowerUP;// No creo que deveria estar aca
    
    protected override void Awake()
    {
        _isPowerUP = false;
        _gunsDictionary = new Dictionary<Weapon, IGun>();
        base.Awake();
        _inputs = GetComponent<PlayerInputs>();
        _anim = GetComponent<PlayerAnimaion>();
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
        if (!_inputs) return;
        _inputs.OnMovementInput += Move;
        _inputs.OnMovementInput += UpdateMovementAnim;
        _inputs.OnFireInput += Fire;
        _inputs.OnDodgeInput += Dodge;

    }

    private void OnDisable()
    {
        if (!_inputs) return;
        _inputs.OnMovementInput -= Move;
        _inputs.OnMovementInput -= UpdateMovementAnim;
        _inputs.OnFireInput -= Fire;
        _inputs.OnDodgeInput -= Dodge;
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

    public float GetMoveAmount() => _inputs.MoveAmount;

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
    public void Dodge()
    {
       //play dodge anim
       if(_anim)
           _anim.ToggleDodge();
       //set invulnerable for a time in seconds
       //ToDo: Dodge animation were at the begining calls to a SetInvulnerable(true) an at the end SetInvulnerable(false)
       _damageable.SetInvulnerable(_invulnerableTime);
    }

    public void UpdateMovementAnim(Vector3 direction)
    {
        if (_anim)
            _anim.UpdateMovementAnim(direction);
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
