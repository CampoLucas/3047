using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Bracelets : Ship
{
    private Boss _boss;
    private Animator _anim;
    private BossGun _gun;

    [SerializeField] private GameObject _explosion;

    protected override void Awake()
    {
        _boss = GetComponentInParent<Boss>();
        _anim = GetComponent<Animator>();
        _gun = GetComponent<BossGun>();
    }

    protected override void Start()
    {
        base.Start();
        if(_boss)
            _boss.OnDestroyedBracelet.AddListener(OnDestroyedBraceletListener);
    }

    public override void OnDieListener()
    {
        _boss.OnDestroyedBracelet?.Invoke();
        _boss.TakeDamage(_boss.Data.Life / 4);
        _boss.IncrementRotationSpeed(30);
        _boss.ChangeRotationDirection();
        Instantiate(_explosion, transform.position, Quaternion.identity);
        base.OnDieListener();
    }

    private void OnDestroyedBraceletListener()
    {
        _damageable.ResetValues();
        _gun.ChangeFireRate(30);
    }

    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
        _anim.SetTrigger("Damage");
    }

    public void ChangeFireRate(float rate) => _gun.ChangeFireRate(rate);


}
